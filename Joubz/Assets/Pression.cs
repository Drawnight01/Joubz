using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pression : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = transform.parent.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            anim.Play("Pression");
        }
    }
}
