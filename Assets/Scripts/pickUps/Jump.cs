using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public void PowerJump()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().jumpHeigth = 1.2f;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().gravity = 6f;
    }
}