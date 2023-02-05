using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    
    Vector3 aimPoint;
    bool shooting;
    float shootTimer;
    Collectable currentCollectable;
    GameObject hookInstance;

    [SerializeField] InventoryManager inventory;
    [SerializeField] Transform canyon; 
    [SerializeField] GameObject hook;
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

            currentCollectable = inventory.RemoveItem();//cambiar 

            if (currentCollectable != null)
            {
                currentCollectable.gameObject.SetActive(true);
                currentCollectable.transform.parent = null;
                currentCollectable.transform.position = canyon.position;
                currentCollectable.GetComponent<Rigidbody>().Sleep();

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

            hookInstance = GameObject.Instantiate(hook, canyon);    

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
    public void SaveCollectable(Collectable collectable)
    {
        inventory.AddToInventory(collectable);
    }
}

