using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seedbed : MonoBehaviour
{
    [SerializeField] Seed plantedSeed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Seed seedComponent) && plantedSeed == null)
        {
            plantedSeed = seedComponent;
            plantedSeed.transform.position = transform.position;
            plantedSeed.transform.position += new Vector3(0,1,0);
            plantedSeed.ToPlant();
            plantedSeed.rigidbody.Sleep();
            plantedSeed.transform.parent = transform;
        }
    }
}
