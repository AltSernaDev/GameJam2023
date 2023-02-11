using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    
    Vector3 aimPoint;
    bool shooting;
    public bool open, suck;
    float shootTimer, openTimer, suckTimer;
    Seeds currentCollectable;
    GameObject hookInstance;
    SkinnedMeshRenderer skinnedMeshRenderer;

    [SerializeField] InventoryManager inventory;
    [SerializeField] Transform canyon; 
    [SerializeField] GameObject hook;
    [SerializeField] float fireRate, bulletSpeed, hookSpeed;

    private void Start()
    {
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
    }
    private void Update()
    {
        ActionTool();
        AnimationKeys();
    }

    private void AnimationKeys()
    {
        if (open)
        {
            if (openTimer < 100)
                openTimer += Time.deltaTime * 500;
            else
                openTimer = 100;
        }
        else
        {
            if (openTimer > 0)
                openTimer -= Time.deltaTime * 500;
            else
                openTimer = 0;
        }
        if (suck)
        {
            if (suckTimer < 100)
                suckTimer += Time.deltaTime * 500;
            else
            {
                suckTimer = 100;
                suck = false;
            }
        }
        else
        {
            if (suckTimer > 0)
                suckTimer -= Time.deltaTime * 500;
            else
                suckTimer = 0;
        }

        skinnedMeshRenderer.SetBlendShapeWeight(0, openTimer);
        skinnedMeshRenderer.SetBlendShapeWeight(1, suckTimer);
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
            aimPoint = AimPoint.instance.AimPointV - canyon.position; 

            currentCollectable = inventory.RemoveItem();//cambiar 

            if (currentCollectable != null)
            {
                suck = true;
                currentCollectable.gameObject.SetActive(true);
                currentCollectable.transform.parent = null;
                currentCollectable.transform.position = canyon.position;
                currentCollectable.GetComponent<Rigidbody>().Sleep();

                currentCollectable.GetComponent<Rigidbody>().AddForce(aimPoint.normalized * bulletSpeed, ForceMode.VelocityChange);

                shooting = true;
            }
        }
    }

    void Pull()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            aimPoint = AimPoint.instance.AimPointV - canyon.position; 
            open = true;

            hookInstance = GameObject.Instantiate(hook, canyon);
            hookInstance.GetComponent<Rigidbody>().AddForce(aimPoint.normalized * hookSpeed, ForceMode.VelocityChange);

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
    public bool SaveCollectable(Seeds collectable)
    {
        return inventory.AddToInventory(collectable);
    }
}

