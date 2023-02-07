using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class Mitosis : MonoBehaviour
{
    bool seedIn;
    Seeds seed1, seed2;

    [SerializeField] GameObject genericSeed;
    [SerializeField] Transform spawnSeed;

    GameObject newSeed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Seeds>() != null )
        {
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.transform.rotation = Quaternion.identity;

            if (seedIn)
            {
                seed2 = other.GetComponent<Seeds>();
                MixSeeds(seed1, seed2);
            }
            else
            {
                seed1 = other.GetComponent<Seeds>();
                seedIn = true;
            }
        }
    }

    void MixSeeds(Seeds s1, Seeds s2)
    {
        if (!s1.Hybrid && !s2.Hybrid)
        {
            print((int)s1.Type + " + " + (int)s2.Type + " = " + ((int)s1.Type + (int)s2.Type));

            if (seedSOManager.Instance.serchByKey((int)s1.Type + (int)s2.Type) != null)
            {
                newSeed = Instantiate(genericSeed, spawnSeed.position, Quaternion.Euler(Vector3.zero));
                newSeed.GetComponent<Seeds>().seedSO = (seedSOManager.Instance.serchByKey((int)s1.Type + (int)s2.Type));

                Destroy(s1.gameObject);
                Destroy(s2.gameObject);
            }
            else
            {
                s1.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.back * 150 + Vector3.up * 150);
                s2.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.back * 150 + Vector3.up * 150);
            }
        }
        else
        {
            print("hybrid");
            s1.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.back * 150 + Vector3.up * 150);
            s2.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.back * 150 + Vector3.up * 150);
        }

        seedIn = false;
        s1 = null;
        s2 = null;
    }
}
