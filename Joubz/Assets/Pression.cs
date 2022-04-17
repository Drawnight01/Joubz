using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pression : MonoBehaviour
{
    private Animator anim;
    private Animator platAnim1;
    private Animator platAnim2;

    private GameObject verrou;

    void Start()
    {
        anim = transform.parent.GetComponent<Animator>();
        platAnim1 = GameObject.Find("Plat1").GetComponent<Animator>();
        platAnim2 = GameObject.Find("Plat2").GetComponent<Animator>();

        verrou = GameObject.Find("Porte_Ville_ici");
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            anim.Play("Pression");
            platAnim1.Play("Plat");
            platAnim2.Play("Plat2");

            verrou.SetActive(false);
        }
    }
}
