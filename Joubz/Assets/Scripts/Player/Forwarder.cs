using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forwarder : MonoBehaviour
{
    public Transform camAnchor;
    void Update()
    {        
        //target.eulerAngles = new Vector3(transform.parent.rotation.eulerAngles.x, GameObject.Find("CamAchor").transform.rotation.eulerAngles.y, transform.parent.eulerAngles.z);
        transform.localEulerAngles = new Vector3(0, camAnchor.transform.localEulerAngles.y, 0);
    }    
}
