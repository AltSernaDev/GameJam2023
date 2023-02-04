using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    GameObject currentCollectable; //change to collectabale class --A--
    Vector3 aimPoint;
    bool shooting;
    float shootTimer;
    [SerializeField] Transform canyon, hook;
    [SerializeField] float fireRate, bulletSpeed, hookSpeed;


    private void Update()
    {
        aimPoint = AimPoint.instance.aimPoint - canyon.position;

        if (shooting)
            FireRate();
        else
            Action();
    }
    void Action()
    {
        Pull();
        Shoot();
    }
    void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            aimPoint = aimPoint.normalized;
            currentCollectable = GameObject.CreatePrimitive(PrimitiveType.Sphere);//Instantiate(bullet);
            currentCollectable.transform.position = canyon.position;
            currentCollectable.AddComponent<Rigidbody>(); //temp
            currentCollectable.GetComponent<Rigidbody>().AddForce(aimPoint.normalized * bulletSpeed, ForceMode.VelocityChange);

            shooting = true;
        }
    }

    void Pull()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            hook.gameObject.SetActive(true);
            aimPoint = aimPoint.normalized;
            hook.transform.position = canyon.position;
            StartCoroutine(hook.gameObject.GetComponent<Hook>().Return(1f));
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

