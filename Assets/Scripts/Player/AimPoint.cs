using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimPoint : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
    public GameObject target;
    private Vector3 aimPoint;
    public static AimPoint instance;

    public Vector3 AimPointV 
    { 
        get
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, 10000f, layerMask, QueryTriggerInteraction.Ignore))
            {
                target = hit.transform.gameObject;
                aimPoint = hit.point;
            }
            else
            {
                target = null;
                aimPoint = transform.forward * 10000f;
            }
            return aimPoint;
        }
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }
}
