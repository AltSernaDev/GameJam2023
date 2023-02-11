using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBuffS : MonoBehaviour, SpecialBehaviour
{
    public void SAction(GameObject actor)
    {
        if (actor.GetComponent<PlantedSeeds>())
        {
            if (actor.GetComponent<PlantedSeeds>().TimeBuff())
            {
                //particle system
                Destroy(transform.parent.gameObject);
            }
        }
    }
}
