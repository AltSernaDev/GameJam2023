using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeSeed : int
{
    generic = 0, a = 1, b = 2, c = 4, d = 8, ab = 3, bc = 6, ac = 5, da = 9, db = 10, dc = 12
}

public class Seeds : MonoBehaviour
{
    public SeedsSO seedSO;

    private TypeSeed type;
    private int health;
    private Sprite icon;
    private GameObject skin;
    private bool plantable;

    [SerializeField] GameObject plantGeneric;
    [SerializeField] Transform childToSkin;

    GameObject plantSeed;
    private bool hybrid;

    public TypeSeed Type { get => type; }
    public int Health { get => health; }
    public Sprite Icon { get => icon; }
    public GameObject Skin { get => skin; }
    public bool Hybrid { get => hybrid; }
    public bool Plantable { get => plantable; }

    public void SetValues()
    {
        if (seedSO != null)
        {
            Instantiate(seedSO.skin, childToSkin);

            type = seedSO.type;
            health = seedSO.health;
            icon = seedSO.icon;
            skin = seedSO.skin;
            hybrid = seedSO.hybrid;
            plantable = seedSO.plantable;
        }
    }
    private void Start()
    {
        SetValues();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (seedSO.plantable && other.CompareTag("plantZone") && other.GetComponent<plantZone>() != null)
        {
            plantZone plantZone = other.GetComponent<plantZone>();

            if (!plantZone.zoneUsed)
            {
                plantZone.zoneUsed = true;

                plantSeed = Instantiate(plantGeneric, plantZone.seedPosition);
                plantSeed.GetComponent<PlantedSeeds>().seedSO = seedSO;
                plantSeed = null;

                Destroy(gameObject);
            }
        }
    }
    public void ReceiveDamage(int dmg)
    {
        health -= dmg;

        if(health <= 0)
            Destroy(gameObject);
    }
}
