using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Hook : MonoBehaviour
{
    GameObject target;
    Transform canyon;
    LineRenderer lineRenderer;
    bool hasTarget = false;

    void Start()
    {
        canyon = transform.parent;
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        gameObject.SetActive(false);
    }
    void Update()
    {
        lineRenderer.SetPosition(0, canyon.position);
        lineRenderer.SetPosition(1, transform.position);

        if (canyon.position == transform.position && target != null && hasTarget)
        {
            gameObject.GetComponent<Rigidbody>().Sleep();
            StartCoroutine(Drop());
            hasTarget = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponent<Rigidbody>().Sleep();
        StartCoroutine(Comeback(0f));

        if (other.gameObject.layer == 7)
        {
            target = other.gameObject;
            target.transform.parent = transform;
            hasTarget = true;
        }
    }

    IEnumerator Drop()
    {
        yield return new WaitForSeconds(0.2f);

        transform.parent.parent.gameObject.GetComponent<Tool>().SaveCollectable(target.GetComponent<Collectable>());
        target.gameObject.SetActive(false);
        target = null;
        TurnOff();
    }

    private void TurnOff()
    {
        transform.localPosition = Vector3.zero;
        gameObject.SetActive(false);
    }

    IEnumerator Comeback(float time)
    {
        yield return new WaitForSeconds(time);

        gameObject.GetComponent<Rigidbody>().Sleep();

        while (transform.position != canyon.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, canyon.position, 20 * Time.deltaTime);
            yield return null;
        }
        
        yield return new WaitUntil(() => target == null);
        TurnOff();
    }
    public void Return(float time)
    {
        StartCoroutine(Comeback(time));
    }
}
