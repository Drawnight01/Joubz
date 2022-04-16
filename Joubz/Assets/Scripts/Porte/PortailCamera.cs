using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortailCamera : MonoBehaviour
{
    public Transform playerCamera, portal, otherPortal;

    void Start()
    {
        playerCamera = GameObject.Find("Player").transform.GetChild(2).GetChild(0);
    }

    void Update()
    {
        Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;
        transform.position = portal.position + playerOffsetFromPortal;

        float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.rotation, otherPortal.rotation);

        Quaternion portalRotationDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
        Vector3 newCameraDirection = portalRotationDifference * playerCamera.forward;
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
    }
}
