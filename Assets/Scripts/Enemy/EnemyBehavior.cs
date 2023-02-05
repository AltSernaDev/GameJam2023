using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] float damage;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Plant"))
        {
            Seed enemySeed = collision.gameObject.GetComponent<Seed>();

            enemySeed.ReceiveDamage(damage);
        }
    }
}
