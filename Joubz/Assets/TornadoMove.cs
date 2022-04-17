using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoMove : MonoBehaviour
{
    public float force;

    private Rigidbody rbPlayer;

    
    void Start()
    {
        rbPlayer = GameObject.FindWithTag("Player").GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            rbPlayer.AddForce(transform.up * force, ForceMode.Force);
        }
    }
}
