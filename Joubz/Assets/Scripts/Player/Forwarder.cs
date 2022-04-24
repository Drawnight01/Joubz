using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forwarder : MonoBehaviour
{    
    void Update()
    {        
        //target.eulerAngles = new Vector3(transform.parent.rotation.eulerAngles.x, GameObject.Find("CamAchor").transform.rotation.eulerAngles.y, transform.parent.eulerAngles.z);
        transform.localEulerAngles = new Vector3(0, GameObject.Find("CamAchor").transform.localEulerAngles.y, 0);
    }    
}
