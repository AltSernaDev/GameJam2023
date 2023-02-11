using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBuffS : MonoBehaviour, SpecialBehaviour
{
    public void SAction(GameObject actor)
    {
        if (actor.GetComponent<PlantedSeeds>())
        {
            if (actor.GetComponent<PlantedSeeds>().DropBuff())
            {
                //particle system
                Destroy(transform.parent.gameObject);
            }
        }
    }
}
