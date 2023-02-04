using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seedbed : MonoBehaviour
{
    [SerializeField] Seed plantedSeed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Seed seedComponent))
        {
            plantedSeed = seedComponent;
            plantedSeed.transform.position = transform.position;
            plantedSeed.ToPlant();
            plantedSeed.rigidbody.Sleep();
            plantedSeed.transform.parent = transform;
        }
    }
}
