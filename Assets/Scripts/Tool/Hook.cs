using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Hook : MonoBehaviour
{
    [SerializeField] float throwTime;
    float timer;
    GameObject target;
    Transform canyon;
    LineRenderer lineRenderer;

    enum State
    {
        Thrown,
        Hit,
        PickingUp,
        Destroy
    }
    State state;

    void Start()
    {
        canyon = transform.parent;
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        gameObject.GetComponent<Rigidbody>().AddForce((AimPoint.instance.aimPoint - canyon.position).normalized * 20, ForceMode.VelocityChange);
    }
    void Update()
    {
        lineRenderer.SetPosition(0, canyon.position);
        lineRenderer.SetPosition(1, transform.position);

        switch (state)
        {
            case State.Thrown:
                Throw();
                break;
            case State.Hit:
                OnHit();
                break;
            case State.PickingUp:
                Comeback();
                break;
            case State.Destroy:
                DestroyTarget();
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.isTrigger)
        {
            state = State.Hit;
            target = other.gameObject;
        }

    }
    void Throw()
    {
        if (timer >= throwTime)
        {
            gameObject.GetComponent<Rigidbody>().Sleep();
            state = State.PickingUp;
        }
        timer += Time.deltaTime;
    }
    void OnHit()
    {
        if (target.gameObject.layer == 7)
        {
            target.transform.parent = transform;
            target.GetComponent<Rigidbody>().Sleep();
        }
        else
            target = null;

        gameObject.GetComponent<Rigidbody>().Sleep();
        state = State.PickingUp;
    }
    bool Return()
    {
        bool done = false;
        if (transform.position != canyon.position)
            transform.position = Vector3.MoveTowards(transform.position, canyon.position, 20 * Time.deltaTime);
        else
            done = true;
        return done;
    }
    void Comeback()
    {
        if (Return())
            state = State.Destroy;  
    }
    bool DropToInventory()
    {
        bool done = false;
        if (target != null)
        {           
            target.transform.parent = null;
            target.GetComponent<Rigidbody>().Sleep();
            transform.parent.parent.gameObject.GetComponent<Tool>().SaveCollectable(target.GetComponent<Collectable>()); // refactory collectable
            done = true;
        }
        else
            done = true;
        return done;
    }
    void DestroyTarget()
    {
        if (DropToInventory())
        {
            if (target != null)
            {
                target.SetActive(false);
                target = null;
            }
            else
                Destroy(gameObject);
        }
    }
}
