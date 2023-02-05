using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class Mitosis : MonoBehaviour
{
    bool seedIn;
    Seeds seed1, seed2;
    [SerializeField] GameObject[] prefabsSeeds;
    [SerializeField] GameObject genericSeed;
    [SerializeField] Transform spawnSeed;
    GameObject thisSeed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Seeds>() != null)
        {
            if (other.GetComponent<Seeds>().combinada == false)
            {
                other.GetComponent<Seeds>().rb.velocity = Vector3.zero;
                other.transform.rotation = Quaternion.identity;

                if (seedIn)
                {
                    seed2 = other.GetComponent<Seeds>();
                    MixSeeds(seed1, seed2);

                    Destroy(seed1.gameObject);
                    Destroy(seed2.gameObject);
                    seed1 = null;
                    seed2=null;
                }
                else
                {
                    seed1 = other.GetComponent<Seeds>();
                    seedIn = true;
                }
            }
            else
            {
                seed1 = null;
                seed2 = null;
                other.GetComponent<Seeds>().rb.AddForce(Vector3.forward * 50);
            }
        }
    }

    void MixSeeds(Seeds s1,Seeds s2)
    {
        if(s1.tipo==s2.tipo)
        {
            if (s1.tipo == Seeds.TipoSeed.d)
            {
                //Drop seeds
                s1.rb.velocity = Vector3.forward * 10;
                s2.rb.velocity = Vector3.forward * 10;
            }
            else
            {
                thisSeed=Instantiate(genericSeed, spawnSeed);
                thisSeed.GetComponent<Seeds>().tipo = s1.tipo + 1;
                seedIn = false;
            }
        }
        else
        {
            switch(s1.tipo)
            {
                case Seeds.TipoSeed.a:
                    switch(s2.tipo)
                    {
                        case Seeds.TipoSeed.b:
                            thisSeed = Instantiate(genericSeed, spawnSeed);
                            thisSeed.GetComponent<Seeds>().tipo = Seeds.TipoSeed.ab;
                            break;
                        case Seeds.TipoSeed.c:
                            thisSeed = Instantiate(genericSeed, spawnSeed);
                            thisSeed.GetComponent<Seeds>().tipo = Seeds.TipoSeed.ac;
                            break;
                        case Seeds.TipoSeed.d:
                            thisSeed = Instantiate(genericSeed, spawnSeed);
                            thisSeed.GetComponent<Seeds>().tipo = Seeds.TipoSeed.da;
                            break;
                    }
                    break;

                case Seeds.TipoSeed.b:
                    switch (s2.tipo)
                    {
                        case Seeds.TipoSeed.a:
                            thisSeed = Instantiate(genericSeed, spawnSeed);
                            thisSeed.GetComponent<Seeds>().tipo = Seeds.TipoSeed.ab;
                            break;
                        case Seeds.TipoSeed.c:
                            thisSeed = Instantiate(genericSeed, spawnSeed);
                            thisSeed.GetComponent<Seeds>().tipo = Seeds.TipoSeed.bc;
                            break;
                        case Seeds.TipoSeed.d:
                            thisSeed = Instantiate(genericSeed, spawnSeed);
                            thisSeed.GetComponent<Seeds>().tipo = Seeds.TipoSeed.db;
                            break;
                    }
                    break;

                case Seeds.TipoSeed.c:
                    switch (s2.tipo)
                    {
                        case Seeds.TipoSeed.a:
                            thisSeed = Instantiate(genericSeed, spawnSeed);
                            thisSeed.GetComponent<Seeds>().tipo = Seeds.TipoSeed.ac;
                            break;
                        case Seeds.TipoSeed.b:
                            thisSeed = Instantiate(genericSeed, spawnSeed);
                            thisSeed.GetComponent<Seeds>().tipo = Seeds.TipoSeed.bc;
                            break;
                        case Seeds.TipoSeed.d:
                            thisSeed=Instantiate(genericSeed, spawnSeed);
                            thisSeed.GetComponent<Seeds>().tipo = Seeds.TipoSeed.dc;
                            break;
                    }
                    break;

                case Seeds.TipoSeed.d:
                    switch (s2.tipo)
                    {
                        case Seeds.TipoSeed.a:
                            thisSeed=Instantiate(genericSeed, spawnSeed);
                            thisSeed.GetComponent<Seeds>().tipo = Seeds.TipoSeed.da;
                            break;
                        case Seeds.TipoSeed.b:
                            thisSeed=Instantiate(genericSeed, spawnSeed);
                            thisSeed.GetComponent<Seeds>().tipo = Seeds.TipoSeed.db;
                            break;
                        case Seeds.TipoSeed.c:
                            thisSeed=Instantiate(genericSeed, spawnSeed);
                            thisSeed.GetComponent<Seeds>().tipo = Seeds.TipoSeed.dc;
                            break;
                    }
                    break;
            }
        }

        seedIn = false;
        s1 =null; 
        s2=null;
    }

}
