using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    bool da, db, dc;
    [SerializeField] GameObject panel;

    private void Awake()
    {
        panel.SetActive(false);
    }
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
            StartCoroutine(Final());
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
    IEnumerator Final()
    {
        yield return new WaitForSeconds(2);

        panel.SetActive(true);

        yield return new WaitForSeconds(8);

        ScenesManager.instance.LoadScene(0);
    }
}
