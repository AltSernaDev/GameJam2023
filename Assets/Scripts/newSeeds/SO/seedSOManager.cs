using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seedSOManager : MonoBehaviour
{
    public static seedSOManager Instance;
    [SerializeField] int[] keys;
    [SerializeField] SeedsSO[] seedsSO;

    private void Awake()
    {
        if (Instance != null)
            Destroy(this);
        else
            Instance = this;
    }

    public SeedsSO serchByKey(int key_)
    {
        for (int i = 0; i < keys.Length; i++)
        {
            if (keys[i] == key_)
                return seedsSO[i];
        }
        return null;
    }
}
