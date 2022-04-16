using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Animations;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public float maxSpeed = 30f;
    
    public float jumpForce = 10f;
    public float valGravity = 9.5f;

    public float rotationSpeed;

    private Quaternion target;
    private Animator animPerso;

    public Vector2 direction = new Vector2(0,0);
    private Rigidbody rbPlayer;
    private GameObject camAchor;
    public bool isGrounded;

   
    void Awake()
    {
        rbPlayer = GetComponent<Rigidbody>();
        camAchor = transform.GetChild(2).gameObject;
        animPerso = transform.GetChild(0).GetComponent<Animator>();        
    }    

    void FixedUpdate()
    {
        Move();
        Gravity();              
    }


    private void Move()
    {
        Vector3 vectMove = (transform.GetChild(3).transform.forward.normalized * direction.y) + (transform.GetChild(3).transform.right.normalized * direction.x);
        vectMove = speed * vectMove;
        rbPlayer.velocity  +=  vectMove * Time.deltaTime;
        rbPlayer.velocity = Vector3.ClampMagnitude(rbPlayer.velocity, maxSpeed);
        animPerso.SetFloat("Blend", rbPlayer.velocity.magnitude);

        if (direction != Vector2.zero)
            target = Quaternion.LookRotation((transform.GetChild(3).transform.forward.normalized * direction.y) + (transform.GetChild(3).transform.right.normalized * direction.x), (transform.GetChild(3).transform.up));


    }
    
    public void SetDir(InputAction.CallbackContext context)
    {        
        direction = context.ReadValue<Vector2>();     
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if(isGrounded)
            rbPlayer.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    
    private void Gravity()
    {
        rbPlayer.velocity -= transform.up * valGravity * rbPlayer.mass * Time.deltaTime;

        RaycastHit hit;
        isGrounded = Physics.Raycast(transform.position, -transform.up, out hit, 0.3f);
        

        if (isGrounded)
        {
            // Stick to surface
            transform.position = hit.point;            
            
            // Align to surface normal
            Quaternion fro = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, fro, Time.deltaTime * 10f);
            transform.GetChild(0).rotation = Quaternion.Slerp(transform.GetChild(0).rotation, target, Time.deltaTime * rotationSpeed);

        }
        else
        {
            
            Debug.Log("Lost contact...");
        }
    }
}
