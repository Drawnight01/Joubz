using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Parameters")]
    public float speed = 10f;
    public float maxSpeed = 30f;
    public bool isGrounded;
    private float speedMult;
    [HideInInspector] public Vector3 vectMove;


    [Header("Rotation Parameters")]
    public float rotationSpeed;
    private Quaternion target;
    [HideInInspector] public Animator animPerso;
    private Vector2 direction = new Vector2(0,0);
    private Rigidbody rbPlayer;

    [Header("Jump Parameters")]
    public float jumpForce = 10f;    
    public float delayToMove;
    public AnimationCurve curve;
    [HideInInspector] public bool jump;
    private float currentTime;
    private int comptSaut = 0;


    [Header("Garvity Parameters")]
    public float valGravity = 9.5f;
    private float expVal = 1f;
    public float minimum = 1.0F;
    public float maximum = 1.5F;
    static float t = 0.0f;
    public float SmoothGravRota;


    void Awake()
    {
        rbPlayer = GetComponent<Rigidbody>();        
        animPerso = transform.GetChild(0).GetComponent<Animator>();
    }    

    void FixedUpdate()
    {
        Move();
        Gravity();              
    }
    private void Update()
    {
        
        ExpValue();
        JumpLogic();
        animPerso.SetBool("isGrounded", isGrounded);

        if (isGrounded && comptSaut != 0)
            comptSaut = 0;
    }
    
    private void Move()
    {
        
        vectMove = (transform.GetChild(3).transform.forward.normalized * direction.y) + (transform.GetChild(3).transform.right.normalized * direction.x);        
        vectMove = speed * vectMove;        
        rbPlayer.velocity  =  vectMove * speedMult;
        
        rbPlayer.velocity = Vector3.ClampMagnitude(rbPlayer.velocity, maxSpeed);
        animPerso.SetFloat("Blend", rbPlayer.velocity.magnitude);

        if (direction != Vector2.zero)
        {
            target = Quaternion.LookRotation((transform.GetChild(3).transform.forward.normalized * direction.y) + (transform.GetChild(3).transform.right.normalized * direction.x), (transform.GetChild(3).transform.up));            
        }
    }
    
    public void SetDir(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();

        if (context.canceled)
            direction = Vector2.zero;
    }

    
    public void Jump(InputAction.CallbackContext context)
    {
        if (( isGrounded || comptSaut < 1) && context.performed)
        {
            t = 0.0f;
            expVal = 1f;
            animPerso.SetTrigger("Jump"); 
            jump = true;
            if(comptSaut < 1)
            {
                GetComponent<FXSpawn>().SmokeLand();
                currentTime = 0;
                comptSaut++;
            }
            else
            {
                
                comptSaut = 0;
            }
        }        
    }   

    private void JumpLogic()
    {
        if(jump)
        {
            currentTime += Time.fixedDeltaTime;
            float percent = currentTime / delayToMove;
            rbPlayer.AddForce(transform.up * jumpForce * curve.Evaluate(percent), ForceMode.Impulse);                       
        }

        if(currentTime >= delayToMove)
        {
            currentTime = 0;
            jump = false;
        }

    }

    public void Echap(InputAction.CallbackContext context)
    {
        Debug.Log("Echap");
        SceneManager.LoadScene("In_Game", LoadSceneMode.Additive);
    }

    
    
    private void ExpValue()
    {       
        if (!isGrounded)
        {
            expVal = Mathf.Lerp(minimum, maximum, t);
            t += 0.5f * Time.deltaTime;
            speedMult = 0.7f;
        }
            
        
        if (isGrounded)
        {            
            t = 0.0f;
            expVal = 1f;
            speedMult = 1f;
        }
    }

    

    private void Gravity()
    {
        rbPlayer.velocity -= transform.up * Mathf.Pow(valGravity, expVal) * rbPlayer.mass * Time.deltaTime;
        RaycastHit hit;
        isGrounded = Physics.Raycast(transform.position, -transform.up, out hit, 0.3f);
        

        if (isGrounded && !hit.transform.CompareTag("Escaliers"))
        {
            // Stick to surface
            transform.position = hit.point;            
            
            // Align to surface normal
            Quaternion fro = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, fro, Time.deltaTime * SmoothGravRota);
            transform.GetChild(0).rotation = Quaternion.Slerp(transform.GetChild(0).rotation, target, Time.deltaTime * rotationSpeed);

        }
        else
        {
            transform.GetChild(0).rotation = Quaternion.Slerp(transform.GetChild(0).rotation, target, Time.deltaTime * rotationSpeed);
        }
    }

    
}
