using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JoystickCamera : MonoBehaviour
{
    [SerializeField]
    float sensitivityX = 8f;    
    float xRotation = 0f;


    [SerializeField] Transform playerCamera;
    [SerializeField] Transform player;
    [SerializeField] float xClamp = 85f;
    [SerializeField] float minXClamp = 0f;

     
    public float camDistance;
    public LayerMask maskCam;
    public float lerpTime = 5f;
    public AnimationCurve curve;
    public Vector2 camDir;

    private void Start()
    {
        playerCamera = transform.GetChild(0);
        player = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {        
        CameraColision();
        RotateCam();
        //CamFollow();
    }

    private void CamFollow()
    {
        transform.position = Vector3.Lerp(transform.position, player.position, curve.Evaluate(Time.deltaTime * lerpTime));
        transform.rotation = Quaternion.Lerp(transform.rotation, player.rotation, curve.Evaluate(Time.deltaTime * lerpTime));
    }

    private void RotateCam()
    {
        //transform.Rotate(transform.up, camDir.x * sensitivityX * Time.deltaTime, Space.Self);
        xRotation += camDir.y;
        xRotation = Mathf.Clamp(xRotation, minXClamp, xClamp);
        Vector3 targetRotation = transform.localEulerAngles;
        targetRotation.x = xRotation;
        targetRotation.y += camDir.x * sensitivityX;
        targetRotation.z = 0;
        transform.localEulerAngles = targetRotation;
    }

    public void CameraRotation(InputAction.CallbackContext context)
    {
        camDir = context.ReadValue<Vector2>();
    }
       

    void CameraColision()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, -transform.forward, out hit, camDistance, maskCam))
        {            
            playerCamera.position = Vector3.Lerp(playerCamera.position, hit.point + playerCamera.forward * 0.2f, curve.Evaluate( Time.deltaTime * lerpTime));
        }
        else
        {
            playerCamera.localPosition = new Vector3(0f, 0, -4f);
        }
    }
}
