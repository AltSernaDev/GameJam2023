using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeds : MonoBehaviour
{
    int health = 100;
    public Rigidbody rb;
    //[SerializeField] SkinnedMeshRenderer modelo;
    public Sprite icon;
    [SerializeField] GameObject plantGeneric;
    int thisSeedSkin;
    [SerializeField] GameObject[] skins;
    [SerializeField] Transform childToSkin;
    GameObject plantSeed;

    public bool plantable, combinada;
    float growthTime;
    [ Range(2, 4)] int dropCount;
    [Range(0, 1)] float probabilidad;
    int growthStage;
    float stageOfGrowingTime;

    public enum TipoSeed
    {
        a,b, c, d, ab,bc,ac,da,db,dc,generic
    }

    public TipoSeed tipo;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        switch (tipo)
        {
            case TipoSeed.a:
                thisSeedSkin = 0;
                probabilidad = 0.65f;
                combinada = false;
                dropCount = 2; // +1 si probabilidad contraria
                growthTime = 45;
                stageOfGrowingTime = growthTime / 4;
                growthStage= 0;
                plantable = true;
                break;
            case TipoSeed.b:
                thisSeedSkin =1;
                probabilidad = 0.70f;
                combinada = false;
                dropCount = 2;  // +1 si probabilidad contraria
                growthTime = 70;
                stageOfGrowingTime = growthTime / 4;
                growthStage = 0;
                plantable = true;

                break;
            case TipoSeed.c:
                thisSeedSkin = 2;
                probabilidad = 0.85f;
                combinada = false;
                dropCount = 2;  // +1 si probabilidad contraria
                growthTime = 100;
                stageOfGrowingTime = growthTime / 4;
                growthStage = 0;
                plantable = true;

                break;
            case TipoSeed.d:
                thisSeedSkin = 3;
                probabilidad = 0.95f;
                combinada = false;
                dropCount = 2;  // +1 si probabilidad contraria
                growthTime = 200;
                stageOfGrowingTime = growthTime / 4;
                growthStage = 0;
                plantable = true;

                // ==================== Seeds Mezcladas ====================

                break;
            case TipoSeed.ab:
                thisSeedSkin = 4;
                probabilidad = 0.60f;
                combinada = true;
                dropCount = 3;  // +1 si probabilidad contraria
                growthTime = 70;
                stageOfGrowingTime = growthTime / 4;
                growthStage = 0;
                plantable = true;

                break;
            case TipoSeed.bc:
                thisSeedSkin = 5;
                probabilidad = 0.70f;
                combinada = true;
                dropCount = 2;  // +1 si probabilidad contraria
                growthTime = 100;
                stageOfGrowingTime = growthTime / 4;
                growthStage = 0;
                plantable = true;

                break;
            case TipoSeed.ac:
                thisSeedSkin = 6;
                probabilidad = 0.85f;
                combinada = true;
                dropCount = 2;  // +1 si probabilidad contraria
                growthTime = 150;
                stageOfGrowingTime = growthTime / 4;
                growthStage = 0;
                plantable = true;

                // ==================== Seeds tipo D ====================

                break;
            case TipoSeed.da:
                thisSeedSkin = 7;
                probabilidad = 1;
                combinada = true;
                growthTime = 9999;
                stageOfGrowingTime = growthTime / 4;
                growthStage = 0;
                plantable = false;

                break;
            case TipoSeed.db:
                thisSeedSkin = 8;
                probabilidad = 1;
                combinada = true;
                growthTime = 9999;
                stageOfGrowingTime = growthTime / 4;
                growthStage = 0;
                plantable = false;
                break;
            case TipoSeed.dc:
                thisSeedSkin = 9;
                probabilidad = 1;
                combinada = true;
                growthTime = 9999;
                stageOfGrowingTime = growthTime / 4;
                growthStage = 0;
                plantable = false;
                break;
        }

        print(thisSeedSkin);
        print(skins[thisSeedSkin]);

        Instantiate(skins[thisSeedSkin], childToSkin);
    }

    private void Update()
    {
        //lerp de los stages
        //Contador time.deltatime
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (plantable && other.CompareTag("plantZone"))
        {
            //revise si other.gameobject está ocupado o no
            if(other.GetComponent<plantZone>())
            {
                plantZone plantZone=other.GetComponent<plantZone>();
                if(!plantZone.zoneUsed)
                {
                    plantSeed = Instantiate(plantGeneric, plantZone.seedPosition);
                    Destroy(gameObject);
                }
            }
        }
    }*/

    public void ReceiveDamage(int dmg)
    {
        health -= dmg;
    }
}
