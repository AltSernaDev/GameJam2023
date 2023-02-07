using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] int damage;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plant"))
        {
            Seeds enemySeed = collision.gameObject.GetComponent<Seeds>();
            enemySeed.ReceiveDamage(damage * Time.deltaTime);
        }
    }
}
