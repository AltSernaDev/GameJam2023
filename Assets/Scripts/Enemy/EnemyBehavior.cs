using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] int damage;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Plant"))
        {
            Seeds enemySeed = other.gameObject.GetComponent<Seeds>();
            enemySeed.ReceiveDamage(damage * Time.deltaTime);
        }
    }
}
