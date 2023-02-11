using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SeedsSO : ScriptableObject
{
    [Header("General")]
    public TypeSeed type = 0;
    public GameObject skin;

    [Header("Seeds")]
    public int health = 100;
    public Sprite icon;
    public bool hybrid, plantable;
    public GameObject specialBehaviour;

    [Header("Plants")]
    public float growthTime;
    public float probability;
    public int maxDrop;
    public float sizeModifier = 0.5f;
}
