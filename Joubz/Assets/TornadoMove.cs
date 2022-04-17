using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoMove : MonoBehaviour
{
    public float speed;

    private bool inTornado = false;

    private Transform player;

    
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Move()
    {
        if (inTornado)
        {
            player.Translate(transform.up * speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            inTornado = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            inTornado = false;
        }
    }
}
