using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationBehav : MonoBehaviour
{
    public BasicSeed[] combinableSeeds = new BasicSeed[2];
    [SerializeField] Transform seedSpawnPoint;
    public int resultType;

    public void CombineSeeds()
    {
        if (combinableSeeds[0].Status == Seed.GrowthStatus.seed && combinableSeeds[1].Status == Seed.GrowthStatus.seed)
        {
            AddSeeds(combinableSeeds[0], combinableSeeds[1]);
        }
    }
    public void AddSeeds(BasicSeed x, BasicSeed y)
    {
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
}
