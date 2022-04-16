using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public float acceleration = 10f;
    public float jumpForce = 10f;
    public float valGravity = 9.5f;

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
        Move();
        Gravity();
    }
       

    private void Move()
    {
        Vector3 vectMove = (camAchor.transform.forward * direction.y) + (camAchor.transform.right * direction.x);
        vectMove *= speed;
        rbPlayer.velocity = vectMove;
    }

    public void SetDir(InputAction.CallbackContext context)
    {
        
        direction = context.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        rbPlayer.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void Gravity()
    {
        rbPlayer.velocity += transform.up * -valGravity * Time.deltaTime;
        
        RaycastHit hit;
        isGrounded = Physics.Raycast(transform.position, -transform.up, out hit, 0.3f);

        if (isGrounded)
        {
            // Stick to surface
            transform.position = hit.point;

            // Align to surface normal
            Quaternion fro = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, fro, Time.deltaTime * 4f);

        }
        else
        {
            Debug.Log("Lost contact...");
        }
    }
}
