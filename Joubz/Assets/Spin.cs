using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float speed;

    private GameObject[] artos = new GameObject[3];

    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            artos[i] = transform.GetChild(i).gameObject;
        }
    }

    void FixedUpdate()
    {
        transform.Rotate(0, speed, 0);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {

        }
    }
}
