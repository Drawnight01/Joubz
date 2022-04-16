using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public float maxSpeed = 30f;
    
    public float jumpForce = 10f;
    public float valGravity = 9.5f;

    public float rotationSpeed;

    private Quaternion target;

    public Vector2 direction = new Vector2(0,0);
    private Rigidbody rbPlayer;
    private GameObject camAchor;
    private bool isGrounded;

    void Awake()
    {
        rbPlayer = GetComponent<Rigidbody>();
        camAchor = transform.GetChild(2).gameObject;
        
    }    

    void FixedUpdate()
    {
        Gravity();
        Move();
        
    }

    private void Update()
    {
        
    }


    private void Move()
    {
        Vector3 vectMove = (transform.GetChild(3).transform.forward.normalized * direction.y) + (transform.GetChild(3).transform.right.normalized * direction.x);
        vectMove = speed * vectMove;
        rbPlayer.velocity  +=  vectMove * Time.deltaTime;
        rbPlayer.velocity = Vector3.ClampMagnitude(rbPlayer.velocity, maxSpeed);
        
        if (direction != Vector2.zero)
            transform.GetChild(0).rotation = Quaternion.Slerp(transform.GetChild(0).rotation, target, Time.deltaTime * rotationSpeed);
        
    }
    
    public void SetDir(InputAction.CallbackContext context)
    {        
        direction = context.ReadValue<Vector2>(); 
        
        if(direction != Vector2.zero)
            target = Quaternion.LookRotation((transform.GetChild(3).transform.forward * direction.y) + (transform.GetChild(3).transform.right * direction.x), (transform.GetChild(3).transform.up));       
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

        if (isGrounded && !hit.transform.gameObject.CompareTag("Escaliers"))
        {
            // Stick to surface
            transform.position = hit.point;

            // Align to surface normal
            Quaternion fro = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, fro, Time.deltaTime * 6f);

        }
        else
        {
            Debug.Log("Lost contact...");
        }
    }
}
