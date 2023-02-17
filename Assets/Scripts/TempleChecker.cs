using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempleChecker : MonoBehaviour
{
    public static TempleChecker tempCheckerCode;

    public enum Temple:int
    {
        outside, temple1, temple2, temple3, temple4
    }

    public bool down;
    public Temple temple;

    [SerializeField] GameObject[] cameras;
    [SerializeField] GameObject[] plane;

    private void Awake()
    {
        tempCheckerCode = this;
    }
    private void Start()
    {
        switch (temple)
        {
            case Temple.outside:
                cameras[0].SetActive(false);
                cameras[1].SetActive(false);
                cameras[2].SetActive(false);
                cameras[3].SetActive(false);

                cameras[4].SetActive(true);
                cameras[5].SetActive(true);
                cameras[6].SetActive(true);
                cameras[7].SetActive(true);

                plane[0].SetActive(true);
                plane[1].SetActive(true);
                plane[2].SetActive(true);
                plane[3].SetActive(true);

                plane[4].SetActive(false);
                plane[5].SetActive(false);
                plane[6].SetActive(false);
                plane[7].SetActive(false);

                break;
            case Temple.temple1:
                cameras[0].SetActive(true);
                cameras[1].SetActive(false);
                cameras[2].SetActive(false);
                cameras[3].SetActive(false);

                cameras[4].SetActive(false);
                cameras[5].SetActive(false);
                cameras[6].SetActive(false);
                cameras[7].SetActive(false);

                plane[0].SetActive(false);
                plane[1].SetActive(false);
                plane[2].SetActive(false);
                plane[3].SetActive(false);

                plane[4].SetActive(true);
                plane[5].SetActive(false);
                plane[6].SetActive(false);
                plane[7].SetActive(false);
                break;
            case Temple.temple2:
                cameras[0].SetActive(false);
                cameras[1].SetActive(true);
                cameras[2].SetActive(false);
                cameras[3].SetActive(false);

                cameras[4].SetActive(false);
                cameras[5].SetActive(false);
                cameras[6].SetActive(false);
                cameras[7].SetActive(false);

                plane[0].SetActive(false);
                plane[1].SetActive(false);
                plane[2].SetActive(false);
                plane[3].SetActive(false);

                plane[4].SetActive(false);
                plane[5].SetActive(true);
                plane[6].SetActive(false);
                plane[7].SetActive(false);
                break;
            case Temple.temple3:
                cameras[0].SetActive(false);
                cameras[1].SetActive(false);
                cameras[2].SetActive(true);
                cameras[3].SetActive(false);

                cameras[4].SetActive(false);
                cameras[5].SetActive(false);
                cameras[6].SetActive(false);
                cameras[7].SetActive(false);

                plane[0].SetActive(false);
                plane[1].SetActive(false);
                plane[2].SetActive(false);
                plane[3].SetActive(false);

                plane[4].SetActive(false);
                plane[5].SetActive(false);
                plane[6].SetActive(true);
                plane[7].SetActive(false);
                break;
            case Temple.temple4:
                cameras[0].SetActive(false);
                cameras[1].SetActive(false);
                cameras[2].SetActive(false);
                cameras[3].SetActive(true);

                cameras[4].SetActive(false);
                cameras[5].SetActive(false);
                cameras[6].SetActive(false);
                cameras[7].SetActive(false);

                plane[0].SetActive(false);
                plane[1].SetActive(false);
                plane[2].SetActive(false);
                plane[3].SetActive(false);

                plane[4].SetActive(false);
                plane[5].SetActive(false);
                plane[6].SetActive(false);
                plane[7].SetActive(true);
                break;
        }
    }
    public void UpdateCameras(int camera)
    {
        temple = (Temple)camera;
        switch (temple)
        {
            case Temple.outside:
                cameras[0].SetActive(false);
                cameras[1].SetActive(false);
                cameras[2].SetActive(false);
                cameras[3].SetActive(false);

                cameras[4].SetActive(true);
                cameras[5].SetActive(true);
                cameras[6].SetActive(true);
                cameras[7].SetActive(true);

                plane[0].SetActive(true);
                plane[1].SetActive(true);
                plane[2].SetActive(true);
                plane[3].SetActive(true);

                plane[4].SetActive(false);
                plane[5].SetActive(false);
                plane[6].SetActive(false);
                plane[7].SetActive(false);

                break;
            case Temple.temple1:
                cameras[0].SetActive(true);
                cameras[1].SetActive(false);
                cameras[2].SetActive(false);
                cameras[3].SetActive(false);

                cameras[4].SetActive(false);
                cameras[5].SetActive(false);
                cameras[6].SetActive(false);
                cameras[7].SetActive(false);

                plane[0].SetActive(false);
                plane[1].SetActive(false);
                plane[2].SetActive(false);
                plane[3].SetActive(false);

                plane[4].SetActive(true);
                plane[5].SetActive(false);
                plane[6].SetActive(false);
                plane[7].SetActive(false);
                break;
            case Temple.temple2:
                cameras[0].SetActive(false);
                cameras[1].SetActive(true);
                cameras[2].SetActive(false);
                cameras[3].SetActive(false);

                cameras[4].SetActive(false);
                cameras[5].SetActive(false);
                cameras[6].SetActive(false);
                cameras[7].SetActive(false);

                plane[0].SetActive(false);
                plane[1].SetActive(false);
                plane[2].SetActive(false);
                plane[3].SetActive(false);

                plane[4].SetActive(false);
                plane[5].SetActive(true);
                plane[6].SetActive(false);
                plane[7].SetActive(false);
                break;
            case Temple.temple3:
                cameras[0].SetActive(false);
                cameras[1].SetActive(false);
                cameras[2].SetActive(true);
                cameras[3].SetActive(false);

                cameras[4].SetActive(false);
                cameras[5].SetActive(false);
                cameras[6].SetActive(false);
                cameras[7].SetActive(false);

                plane[0].SetActive(false);
                plane[1].SetActive(false);
                plane[2].SetActive(false);
                plane[3].SetActive(false);

                plane[4].SetActive(false);
                plane[5].SetActive(false);
                plane[6].SetActive(true);
                plane[7].SetActive(false);
                break;
            case Temple.temple4:
                cameras[0].SetActive(false);
                cameras[1].SetActive(false);
                cameras[2].SetActive(false);
                cameras[3].SetActive(true);

                cameras[4].SetActive(false);
                cameras[5].SetActive(false);
                cameras[6].SetActive(false);
                cameras[7].SetActive(false);

                plane[0].SetActive(false);
                plane[1].SetActive(false);
                plane[2].SetActive(false);
                plane[3].SetActive(false);

                plane[4].SetActive(false);
                plane[5].SetActive(false);
                plane[6].SetActive(false);
                plane[7].SetActive(true);
                break;
        }
    }
    public void SwitchOn(int indexC, int indexP)
    {
        cameras[indexC].SetActive(true);
        plane[indexP].SetActive(true);
    }
    public void SwitchOff(int indexC, int indexP)
    {
        cameras[indexC].SetActive(false);
        plane[indexP].SetActive(false);
    }
}
