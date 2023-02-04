using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Hook : MonoBehaviour
{
    GameObject target;
    Transform canyon;
    LineRenderer lineRenderer;

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

        if (canyon.position == transform.position && target != null)
            StartCoroutine(Drop());
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameObject.GetComponent<Rigidbody>().Sleep();
        StartCoroutine(Comeback(0f));

        if (collision.gameObject.layer == 7)
        {            
            target = collision.gameObject;
            Destroy(target.GetComponent<Rigidbody>());
            target.transform.parent = transform;
        }
    }
    IEnumerator Drop()
    {
        yield return new WaitForSeconds(0.5f);

        target.AddComponent<Rigidbody>();
        target.transform.parent = null;
        target = null;

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
    }
    public void Return(float time)
    {
        StartCoroutine(Comeback(time));
    }
}
