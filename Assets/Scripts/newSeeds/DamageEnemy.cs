using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour, SpecialBehaviour
{
    public void SAction(GameObject actor)
    {
        if (actor.GetComponent<EnemyBehavior>())
        {
            actor.GetComponent<EnemyBehavior>().ReceiveDamage(100);
            //corroutine particle system
            Destroy(transform.parent.gameObject);
        }
    }
}
