using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationBehav : MonoBehaviour
{
    public List<BasicSeed> combinableSeeds;
    [SerializeField] Transform seedSpawnPoint;
    public int resultType;

    public void CombineSeeds()
    {
        if (combinableSeeds[0].Status == Seed.GrowthStatus.seed && combinableSeeds[1].Status == Seed.GrowthStatus.seed)
        {
            AddSeeds(combinableSeeds[0], combinableSeeds[1]);
        }
    }

    private void Update()
    {
        if(combinableSeeds.Count == 2)
        {
            CombineSeeds();
        }
    }

    public void AddSeeds(BasicSeed x, BasicSeed y)
    {
        combinableSeeds.Clear();
        print("x " + (int)x.seedType + " y " + (int)y.seedType);

        if (x.seedType == y.seedType && (int)x.seedType < 5 && (int)y.seedType < 5)
        {
            resultType = (int)x.seedType + 1;

            if (resultType <= 3)
            {
                SeedSpawnManager.instance.SpawnBasicSeed(resultType , seedSpawnPoint);
                Destroy(x.gameObject);
                Destroy(y.gameObject);
            }
            else if (resultType == 4)
            {
                resultType = 5;

                SeedSpawnManager.instance.SpawnBasicSeed(resultType, seedSpawnPoint);
                Destroy(x.gameObject);
                Destroy(y.gameObject);
            }
        }
        else if (x.seedType != y.seedType)
        {
            GameObject newSeed = new GameObject("New Seed");
            newSeed.AddComponent<CombinatedSeed>();
            CombinatedSeed resultSeed = newSeed.GetComponent<CombinatedSeed>();

            resultType = (int)x.seedType + (int)y.seedType;
            SeedSpawnManager.instance.SpawnCombinedSeed(resultType , seedSpawnPoint);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Plant") && combinableSeeds.Count < 2 && other.TryGetComponent(out BasicSeed newSeed))
        {
            combinableSeeds.Add(newSeed);
            other.gameObject.SetActive(false);
        }
    }
}
