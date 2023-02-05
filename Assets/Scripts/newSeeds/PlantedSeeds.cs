using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Seeds;
using UnityEngine.Playables;
using System;

public class PlantedSeeds : MonoBehaviour
{
    SkinnedMeshRenderer skinned;
    [Range(2, 4)] int dropCount;
    [Range(0, 1)] float probabilidad;
    int growthStage;
    float stageOfGrowingTime;
    float actualTime;
    float growthTime;
    [NonSerialized] public bool growing;
    [SerializeField] GameObject[] plantsSkins;
    [SerializeField] GameObject genericSeedDrop;
    [SerializeField] Transform whereDrop;
    GameObject droppingSeed;

    public enum tipoPlant
    {
        a, b, c, d, ab, bc, ac, genericPlant
    }
    public tipoPlant planta;

    private void Start()
    {
        growing = true;
        Instantiate(plantsSkins[(int)planta], gameObject.transform);
        skinned = transform.GetChild(0).GetComponent<SkinnedMeshRenderer>();
        switch (planta)
        {
            case tipoPlant.a:
                probabilidad = 0.65f;
                dropCount = 2; // +1 si probabilidad contraria
                growthTime = 45;
                stageOfGrowingTime = growthTime / 4;
                growthStage = 0;
                break;

            case tipoPlant.b:
                probabilidad = 0.70f;
                dropCount = 2;  // +1 si probabilidad contraria
                growthTime = 70;
                stageOfGrowingTime = growthTime / 4;
                growthStage = 0;
                break;

            case tipoPlant.c:
                probabilidad = 0.85f;
                dropCount = 2;  // +1 si probabilidad contraria
                growthTime = 100;
                stageOfGrowingTime = growthTime / 4;
                growthStage = 0;
                break;

            case tipoPlant.d:
                probabilidad = 0.95f;
                dropCount = 2;  // +1 si probabilidad contraria
                growthTime = 200;
                stageOfGrowingTime = growthTime / 4;
                growthStage = 0;
                break;

            case tipoPlant.ab:
                probabilidad = 0.60f;
                dropCount = 3;  // +1 si probabilidad contraria
                growthTime = 70;
                stageOfGrowingTime = growthTime / 4;
                growthStage = 0;
                break;

            case tipoPlant.bc:
                probabilidad = 0.70f;
                dropCount = 2;  // +1 si probabilidad contraria
                growthTime = 100;
                stageOfGrowingTime = growthTime / 4;
                growthStage = 0;
                break;

            case tipoPlant.ac:
                probabilidad = 0.85f;
                dropCount = 2;  // +1 si probabilidad contraria
                growthTime = 150;
                stageOfGrowingTime = growthTime / 4;
                growthStage = 0;
                break;
        }
    }

    IEnumerator SeedDrops()
    {
        float randProb;
        randProb = UnityEngine.Random.Range(0f, 1f);
        if(randProb>=probabilidad)
        {
            // suelta +1 además
            for (int i = 0; i < dropCount + 1; i++)
            {
                droppingSeed = Instantiate(genericSeedDrop, whereDrop);
                droppingSeed.transform.parent = null;
                float randToForce = UnityEngine.Random.Range(-2, 2);
                droppingSeed.GetComponent<Rigidbody>().AddForce(new Vector3(randToForce, 4, randToForce));
                yield return new WaitForSeconds(0.4f);
            }
        }
        else
        {
            for (int i = 0; i < dropCount; i++)
            {
                droppingSeed = Instantiate(genericSeedDrop, whereDrop);
                droppingSeed.transform.parent = null;
                float randToForce = UnityEngine.Random.Range(-2, 2);
                droppingSeed.GetComponent<Rigidbody>().AddForce(new Vector3(randToForce, 4, randToForce));
                yield return new WaitForSeconds(0.4f);
            }
        }
    }

    private void Update()
    {
        if(growing)
        {
            actualTime += Time.deltaTime;
            skinned.SetBlendShapeWeight(growthStage, (actualTime / stageOfGrowingTime)*100);

            if(actualTime>stageOfGrowingTime)
            {
                growthStage++;
                actualTime = 0;
                if (growthStage>2)
                {
                    growing = false;
                    droppingSeed = Instantiate(genericSeedDrop, whereDrop);
                    droppingSeed.transform.parent = null;
                    StartCoroutine("SeedDrops");
                    //EFECTO DE PARTICULAS
                    Destroy(gameObject);
                }
            }
        }
    }
}
