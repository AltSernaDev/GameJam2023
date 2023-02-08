using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    int keys = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Seeds>() != null)
        {
            switch (other.GetComponent<Seeds>().Type)
            {
                case TypeSeed.d:
                    break;
                case TypeSeed.da:
                    keys++;
                    break;
                case TypeSeed.db:
                    keys++;
                    break;
                case TypeSeed.dc:
                    keys++;
                    break;
                default:
                    break;
            }
        }
        if (keys >= 3)
        {
            //supereme victory
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
                    keys--;
                    break;
                case TypeSeed.db:
                    keys--;
                    break;
                case TypeSeed.dc:
                    keys--;
                    break;
                default:
                    break;
            }
        }
    }
}
