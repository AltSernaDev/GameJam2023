using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Seeds : MonoBehaviour
{
    int health = 100;
    public Rigidbody rb;
    [SerializeField] Sprite[] iconArray;
    public Sprite iconSeed;
    [SerializeField] GameObject plantGeneric;
    int thisSeedSkin=0;
    [SerializeField] GameObject[] skins=new GameObject[10];
    [SerializeField] Transform childToSkin;
    GameObject plantSeed;

    public bool plantable, combinada;


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
                iconSeed = iconArray[(int)tipo];
                thisSeedSkin = 0;
                combinada = false;
                plantable = true;
                break;
            case TipoSeed.b:
                iconSeed = iconArray[(int)tipo];
                thisSeedSkin =1;
                combinada = false;
                plantable = true;

                break;
            case TipoSeed.c:
                iconSeed = iconArray[(int)tipo];
                thisSeedSkin = 2;
                combinada = false;
                plantable = true;

                break;
            case TipoSeed.d:
                iconSeed = iconArray[(int)tipo];
                thisSeedSkin = 3;
                combinada = false;
                plantable = true;

                // ==================== Seeds Mezcladas ====================

                break;
            case TipoSeed.ab:
                iconSeed = iconArray[(int)tipo];
                thisSeedSkin = 4;
                combinada = true;
                plantable = true;

                break;
            case TipoSeed.bc:
                iconSeed = iconArray[(int)tipo];
                thisSeedSkin = 5;
                combinada = true;
                plantable = true;

                break;
            case TipoSeed.ac:
                iconSeed = iconArray[(int)tipo];
                thisSeedSkin = 6;
                combinada = true;
                plantable = true;

                // ==================== Seeds tipo D ====================

                break;
            case TipoSeed.da:
                iconSeed = iconArray[(int)tipo];
                thisSeedSkin = 7;
                combinada = true;
                plantable = false;

                break;
            case TipoSeed.db:
                iconSeed = iconArray[(int)tipo];
                thisSeedSkin = 8;
                combinada = true;
                plantable = false;
                break;
            case TipoSeed.dc:
                iconSeed = iconArray[(int)tipo];
                thisSeedSkin = 9;
                combinada = true;
                plantable = false;
                break;
        }

 
        Instantiate(skins[(int)tipo], childToSkin);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (plantable && other.CompareTag("plantZone"))
        {
            //revise si other.gameobject está ocupado o no
            if(other.GetComponent<plantZone>())
            {
                plantZone plantZone=other.GetComponent<plantZone>();
                if(!plantZone.zoneUsed)
                {
                    plantZone.zoneUsed = true;
                    plantSeed = Instantiate(plantGeneric, plantZone.seedPosition);
                    plantSeed.GetComponent<PlantedSeeds>().planta = (PlantedSeeds.tipoPlant)tipo;
                    plantSeed = null;
                    Destroy(gameObject);
                }
            }
        }
    }

    public void ReceiveDamage(int dmg)
    {
        health -= dmg;
        if(health<=0)
        {
            Destroy(gameObject);
        }
    }
}
