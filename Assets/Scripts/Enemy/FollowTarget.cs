using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowTarget : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] List<Transform> plants = new List<Transform>();
    [SerializeField] Transform target;
    [SerializeField] SkinnedMeshRenderer skin;
    [SerializeField] string tag;

    float time, speed;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(CheckList());
    }
    private void Update()
    {
        Animation();
        FindTarget();
    }

    IEnumerator CheckList()
    {
        yield return null;
        for (int i = 0; i < plants.Count; i++)
        {
            if (plants[i] == null || plants[i].gameObject.activeSelf == false)
                plants.RemoveAt(i);
        }
        yield return new WaitForSeconds(5);
        StartCoroutine(CheckList());
    }

    void Animation()
    {
        speed = agent.velocity.magnitude;

        if (speed > 0)
        {
            if (time > (1 / speed))
                time = 0;
        }
        else
            time = 0;

        time += Time.deltaTime;

        skin.SetBlendShapeWeight(0, (Mathf.Cos(((speed * time + 0.5f) * (2 * Mathf.PI)) + 1) / 2) * 100);
    }

    void FindTarget()
    {
        if (plants.Count > 0 && target == null)
            target = plants[Random.Range(0, plants.Count)];

        if (target != null)
        {
            agent.SetDestination(target.position);

            if (target.gameObject.activeSelf == false)
                target = null;
        }
        else
            agent.SetDestination(transform.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        //if ((1 << other.gameObject.layer) == layer)
        if (other.CompareTag(tag) && !plants.Contains(other.transform))
            plants.Add(other.transform);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(tag) && plants.Contains(other.transform))
        {
            if (other.transform == target)
                target = null;
            plants.Remove(other.transform);
        }
    }
}
