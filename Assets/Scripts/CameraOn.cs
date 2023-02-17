using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOn : MonoBehaviour
{
    [SerializeField] TempleChecker templeChecker;
    [SerializeField] int camera;
    [SerializeField] int plane;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            templeChecker.SwitchOn(camera, plane);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            templeChecker.SwitchOff(camera, plane);
        }
    }
}
