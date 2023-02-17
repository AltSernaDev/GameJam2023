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

    private void Awake()
    {
        tempCheckerCode = this;
    }
}
