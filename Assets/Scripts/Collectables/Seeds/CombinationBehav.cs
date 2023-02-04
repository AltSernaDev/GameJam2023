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
        if (combinableSeeds[0].status == Seed.GrowthStatus.seed && combinableSeeds[1].status == Seed.GrowthStatus.seed)
        {
            AddSeeds(combinableSeeds[0], combinableSeeds[1]);
        }
    }
    public void AddSeeds(BasicSeed x, BasicSeed y)
    {
        print("x " + (int)x.seedType + " y " + (int)y.seedType);

        if (x.seedType == y.seedType && (int)x.seedType < 5 && (int)y.seedType < 5)
        {
            GameObject newSeed = new GameObject("New Seed");
            newSeed.AddComponent<BasicSeed>();
            BasicSeed resultSeed = newSeed.GetComponent<BasicSeed>();

            resultType = (int)x.seedType + 1;

            if (resultType <= 3)
            {
                resultSeed.seedType = (BasicSeed.SeedType)resultType;

                Destroy(x.gameObject);
                Destroy(y.gameObject);
                Instantiate(resultSeed, seedSpawnPoint.transform);
            }
            else if (resultType == 4)
            {
                resultType = 5;
                resultSeed.seedType = (BasicSeed.SeedType)resultType;

                Destroy(x.gameObject);
                Destroy(y.gameObject);
                Instantiate(resultSeed, seedSpawnPoint.transform);
            }
        }
        else if (x.seedType != y.seedType)
        {
            GameObject newSeed = new GameObject("New Seed");
            newSeed.AddComponent<CombinatedSeed>();
            CombinatedSeed resultSeed = newSeed.GetComponent<CombinatedSeed>();

            resultType = (int)x.seedType + (int)y.seedType;
            switch (resultType)
            {
                case 3:
                    resultSeed.seedType = CombinatedSeed.SeedType.AB;
                    Destroy(x.gameObject);
                    Destroy(y.gameObject);
                    Instantiate(resultSeed, seedSpawnPoint.transform);
                    break;

                case 5:
                    resultSeed.seedType = CombinatedSeed.SeedType.BC;
                    Destroy(x.gameObject);
                    Destroy(y.gameObject);
                    Instantiate(resultSeed, seedSpawnPoint.transform);
                    break;

                case 4:
                    resultSeed.seedType = CombinatedSeed.SeedType.AC;
                    Destroy(x.gameObject);
                    Destroy(y.gameObject);
                    Instantiate(resultSeed, seedSpawnPoint.transform);
                    break;

                case 6:
                    resultSeed.seedType = CombinatedSeed.SeedType.DA;
                    Destroy(x.gameObject);
                    Destroy(y.gameObject);
                    Instantiate(resultSeed, seedSpawnPoint.transform);
                    break;

                case 7:
                    resultSeed.seedType = CombinatedSeed.SeedType.DB;
                    Destroy(x.gameObject);
                    Destroy(y.gameObject);
                    Instantiate(resultSeed, seedSpawnPoint.transform);
                    break;

                case 8:
                    resultSeed.seedType = CombinatedSeed.SeedType.DC;
                    Destroy(x.gameObject);
                    Destroy(y.gameObject);
                    Instantiate(resultSeed, seedSpawnPoint.transform);
                    break;
            }
            

        }
    }
}
