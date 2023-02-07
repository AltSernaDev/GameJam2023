using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    GameObject light;
    
    public void PowerLight()
    {
        light = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).GetChild(0).GetChild(1).gameObject;
        light.SetActive(true);
    }
    private void OnDisable()
    {
        PowerLight();
    }
}
