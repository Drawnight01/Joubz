using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortailManager : MonoBehaviour
{
    public Camera cameraH, cameraG, cameraF, cameraE, cameraD, cameraC, cameraB, cameraA;

    public Material cameraMatH, cameraMatG, cameraMatF, cameraMatE, cameraMatD, cameraMatC, cameraMatB, cameraMatA;

    void Start()
    {
        if (cameraA.targetTexture != null)
        {
            cameraA.targetTexture.Release();
        }   
        cameraA.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMatA.mainTexture = cameraA.targetTexture;

        if (cameraB.targetTexture != null)
        {
            cameraB.targetTexture.Release();
        }   
        cameraB.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMatB.mainTexture = cameraB.targetTexture;

        if (cameraC.targetTexture != null)
        {
            cameraC.targetTexture.Release();
        }   
        cameraC.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMatC.mainTexture = cameraC.targetTexture;

        if (cameraD.targetTexture != null)
        {
            cameraD.targetTexture.Release();
        }   
        cameraD.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMatD.mainTexture = cameraD.targetTexture;

        if (cameraE.targetTexture != null)
        {
            cameraE.targetTexture.Release();
        }   
        cameraE.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMatE.mainTexture = cameraE.targetTexture;

        if (cameraF.targetTexture != null)
        {
            cameraF.targetTexture.Release();
        }   
        cameraF.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMatF.mainTexture = cameraF.targetTexture;

        if (cameraG.targetTexture != null)
        {
            cameraG.targetTexture.Release();
        }   
        cameraG.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMatG.mainTexture = cameraG.targetTexture;

        if (cameraH.targetTexture != null)
        {
            cameraH.targetTexture.Release();
        }   
        cameraH.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMatH.mainTexture = cameraH.targetTexture;
    }
}
