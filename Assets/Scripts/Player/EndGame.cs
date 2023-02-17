using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    int keys = 0;
    bool da, db, dc;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Seeds>() != null)
        {
            switch (other.GetComponent<Seeds>().Type)
            {
                case TypeSeed.d:
                    break;
                case TypeSeed.da:
                    da = true;
                    break;
                case TypeSeed.db:
                    db = true;
                    break;
                case TypeSeed.dc:
                    dc = true;
                    break;
                default:
                    break;
            }
        }
        if (da && db && dc) 
        {
            ScenesManager.instance.LoadScene(0);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Seeds>() != null)
        {
            switch (other.GetComponent<Seeds>().Type)
            {
                case TypeSeed.d:
                    break;
                case TypeSeed.da:
                    da = false;
                    break;
                case TypeSeed.db:
                    db = false;
                    break;
                case TypeSeed.dc:
                    dc = false;
                    break;
                default:
                    break;
            }
        }
    }
}
