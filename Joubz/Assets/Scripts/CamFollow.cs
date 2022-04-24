using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform objToFollow;
    public float posLerpSpeed;
    public float rotaLerpSpeed;

    // Update is called once per frame
    void Update()
    {
        Follow();
    }

    void Follow()
    {
        transform.position = Vector3.Lerp(transform.position, objToFollow.position + (objToFollow.gameObject.GetComponent<PlayerMovement>().vectMove / 6), Time.deltaTime * posLerpSpeed);
        //transform.position = objToFollow.position;
        transform.rotation = Quaternion.Lerp(transform.rotation, objToFollow.rotation, Time.deltaTime * rotaLerpSpeed); ;
        //transform.rotation = objToFollow.rotation;
    }
}
