using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] int damage = 10;
    [SerializeField] float health = 50;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Plant"))
        {
            Seeds enemySeed = other.gameObject.GetComponent<Seeds>();
            enemySeed.ReceiveDamage(damage * Time.deltaTime);
        }
    }
    public void ReceiveDamage(float dmg)
    {
        health -= dmg;

        if (health <= 0)
            Destroy(transform.parent.gameObject);
    }
}
