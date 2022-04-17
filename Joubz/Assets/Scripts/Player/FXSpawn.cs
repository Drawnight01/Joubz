using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXSpawn : MonoBehaviour
{
    public GameObject fX_Step;
    public GameObject fX_SmokeLand;

    public void Step()
    {
        GameObject obj = Instantiate(fX_Step, transform.GetChild(0).position, transform.GetChild(0).rotation);
        
        Destroy(obj, 1f);
    }

    public void SmokeLand()
    {
        GameObject obj = Instantiate(fX_SmokeLand, transform.GetChild(0).position, transform.GetChild(0).rotation);

        Destroy(obj, 1f);
    }
}
