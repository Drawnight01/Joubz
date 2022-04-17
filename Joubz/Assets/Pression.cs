using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pression : MonoBehaviour
{
    private Animator anim;
    private Animator platAnim;

    void Start()
    {
        anim = transform.parent.GetComponent<Animator>();
        platAnim = GameObject.Find("Plat1").GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            anim.Play("Pression");
            platAnim.Play("Plat");
        }
    }
}
