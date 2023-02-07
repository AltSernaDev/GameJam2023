using System.Collections;
using UnityEngine;


public class PlantedSeeds : MonoBehaviour
{
    public SeedsSO seedSO;

    TypeSeed type;
    GameObject skin;
    SkinnedMeshRenderer skinned;
    int maxDrop;
    float probability;
    float growthTime;

    int growthStage;
    float stageOfGrowingTime, timer;
    public bool growing;

    [SerializeField] Transform whereDrop;
    [SerializeField] Transform skinParent;
    [SerializeField] GameObject genericSeed;

    GameObject droppingSeed;

    public void SetValues()
    {
        if (seedSO != null)
        {
            growing = true;

            type = seedSO.type;
            skin = seedSO.skin;
            maxDrop = seedSO.maxDrop;
            probability = seedSO.probability;
            growthTime = seedSO.growthTime;

            stageOfGrowingTime = growthTime/4;

            skinned = Instantiate(skin, skinParent.transform).GetComponent<SkinnedMeshRenderer>();
        }
    }
    private void Start()
    {
        SetValues();
    }
    private void Update()
    {
        if (growing)
        {
            timer += Time.deltaTime;
            skinned.SetBlendShapeWeight(growthStage, (timer / stageOfGrowingTime) * 100);

            if (timer > stageOfGrowingTime)
            {
                growthStage++;
                timer = 0;
                if (growthStage > 2)
                {
                    growing = false;
                    StartCoroutine(SeedDrops());
                }
            }
        }
    }
    IEnumerator SeedDrops()
    {
        float randProb = Random.Range(0f, 1f);
        
        if(randProb < probability)
            --maxDrop;

        for (int i = 0; i < maxDrop; i++)
        {
            droppingSeed = Instantiate(genericSeed, whereDrop);
            droppingSeed.GetComponent<Seeds>().seedSO = seedSO;
            droppingSeed.transform.parent = null;
            droppingSeed.GetComponent<Rigidbody>().AddForce(Vector3.forward * 250 + Vector3.right * 300 * Random.Range(-1f, 1f));

            droppingSeed = null;

            yield return new WaitForSeconds(0.5f);
        }

        //partcle system

        yield return null; // wait for particles

        Destroy(gameObject);
    }
}

