using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPlantedSeeds : MonoBehaviour
{
    [SerializeField] SeedsSO seedSO;

    TypeSeed type;
    GameObject skin;
    SkinnedMeshRenderer skinned;
    int maxDrop;
    float probability;
    float growthTime;

    int growthStage;
    float stageOfGrowingTime, stageTimer;
    public bool growing;

    [SerializeField] Transform whereDrop;
    [SerializeField] Transform skinParent;
    [SerializeField] GameObject genericSeed;

    GameObject droppingSeed;
    Vector3 skinBaseScale;
    float skinModifierScale = 0.5f;

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

            stageOfGrowingTime = growthTime / 4;

            skinned = Instantiate(skin, skinParent.transform).GetComponent<SkinnedMeshRenderer>();
            skinBaseScale = skinned.transform.localScale;
            skinModifierScale = seedSO.sizeModifier;
        }
    }
    private void Start()
    {
        SetValues();
        Invoke("CheckSeeds", growthTime);
    }
    private void Update()
    {
        if (growing)
        {
            stageTimer += Time.deltaTime;
            skinned.SetBlendShapeWeight(growthStage, (stageTimer / stageOfGrowingTime) * 100);

            if (stageTimer > stageOfGrowingTime)
            {
                growthStage++;
                stageTimer = 0;
                if (growthStage > 2)
                {
                    growing = false;
                    StartCoroutine(SeedDrops());
                }
            }
            skinned.transform.localScale = skinBaseScale * (skinModifierScale * (stageTimer + growthStage * (stageOfGrowingTime)) / growthTime + 1);
        }
    }

    private void CheckSeeds()
    {
        if (whereDrop.childCount > 0)
            growing = false;
        else
        {
            //particle system
            Destroy(skinned.gameObject);
            skinned = null;
            skinned = Instantiate(skin, skinParent.transform).GetComponent<SkinnedMeshRenderer>();
            growthStage = 0;
            stageTimer = 0;
            growing = true;
        }

        Invoke("CheckSeeds", growthTime);
    }

    IEnumerator SeedDrops()
    {
        for (int i = 0; i < maxDrop - 1; i++)
        {
            droppingSeed = Instantiate(genericSeed, whereDrop);
            droppingSeed.GetComponent<Seeds>().seedSO = seedSO;

            droppingSeed.GetComponent<Rigidbody>().AddForce(Vector3.forward * 250 + Vector3.right * 300 * Random.Range(-1f, 1f));

            droppingSeed = null;

            yield return new WaitForSeconds(0.5f);
        }
    }
}
