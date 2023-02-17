using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    public Transform playerCamera, portal, otherPortal;


    void FixedUpdate()
    {
        Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;
        transform.position = portal.position + playerOffsetFromPortal;

        float angularDiff = Quaternion.Angle(portal.rotation, otherPortal.rotation);
        Quaternion portalRorationDiff = Quaternion.AngleAxis(angularDiff, Vector3.up);
        Vector3 newCamDir = portalRorationDiff * playerCamera.forward;
        transform.rotation = Quaternion.LookRotation(newCamDir, Vector3.up);
    }
}
