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
    float stageOfGrowingTime, StageTimer;
    public bool growing;

    [SerializeField] Transform whereDrop;
    [SerializeField] Transform skinParent;
    [SerializeField] GameObject genericSeed;

    GameObject droppingSeed;
    Vector3 skinBaseScale;
    float skinModifierScale = 0.5f;
    bool timeBuffed, probabiltyBuffed;

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
            skinBaseScale = skinned.transform.localScale;
            skinModifierScale = seedSO.sizeModifier;
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
            StageTimer += Time.deltaTime;
            skinned.SetBlendShapeWeight(growthStage, (StageTimer / stageOfGrowingTime) * 100);

            if (StageTimer > stageOfGrowingTime)
            {
                growthStage++;
                StageTimer = 0;
                if (growthStage > 2)
                {
                    growing = false;
                    StartCoroutine(SeedDrops());
                }
            }
            skinned.transform.localScale = skinBaseScale * (skinModifierScale * (StageTimer + growthStage * (stageOfGrowingTime))/growthTime + 1) ;
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

        transform.GetComponentInParent<PlantZone>().zoneUsed = false;
        Destroy(gameObject);
    }
    public bool TimeBuff()
    {
        if (!timeBuffed)
        {
            growthTime = growthTime / 2;
            stageOfGrowingTime = stageOfGrowingTime / 2;

            timeBuffed = true;
            return true;
        }
        return false;
    }
    public bool DropBuff()
    {
        if (!probabiltyBuffed)
        {
            probability = -1;

            probabiltyBuffed = true;
            return true;
        }
        return false;
    }
}

