using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventAnimator : MonoBehaviour
{
    private FXSpawn scriptFX;

    private void Awake()
    {
        scriptFX = transform.parent.GetComponent<FXSpawn>();
    }

    public void Step()
    {
        scriptFX.Step();
    }
    public void SmokeLand()
    {
        scriptFX.SmokeLand();
    }
}
