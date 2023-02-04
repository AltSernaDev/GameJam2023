using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    
    Vector3 aimPoint;
    bool shooting;
    float shootTimer;
    [SerializeField] InventoryManager inventory;
    [SerializeField] Transform canyon, hook;
    [SerializeField] float fireRate, bulletSpeed, hookSpeed;

    private void Update()
    {
        aimPoint = AimPoint.instance.aimPoint - canyon.position;
        ActionTool();
    }
    void ActionTool()
    {
        if (shooting)
            FireRate();
        else
        {
            Pull();
            Shoot();
        }
    }
    void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            aimPoint = aimPoint.normalized;

            var currentCollectable = inventory.RemoveItem();//cambiar 

            if (currentCollectable != null)
            {
                currentCollectable.transform.position = canyon.position;

                currentCollectable.gameObject.AddComponent<Rigidbody>(); //temp

                currentCollectable.GetComponent<Rigidbody>().AddForce(aimPoint.normalized * bulletSpeed, ForceMode.VelocityChange); 
            }

            shooting = true;
        }
    }

    void Pull()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            aimPoint = aimPoint.normalized;

            hook.gameObject.SetActive(true);            
            hook.transform.position = canyon.position;
            hook.gameObject.GetComponent<Hook>().Return(0.5f);
            hook.GetComponent<Rigidbody>().Sleep();

            hook.GetComponent<Rigidbody>().AddForce(aimPoint.normalized * hookSpeed, ForceMode.VelocityChange);

            shooting = true;
        }
    }
    void FireRate()
    {
        if (shootTimer > (1 / fireRate))
        {
            shooting = false;
            shootTimer = 0;
        }
        else
            shootTimer += Time.deltaTime;
    }
}

