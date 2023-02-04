using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowTarget : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] List<Transform> plants = new List<Transform>();
    [SerializeField] Transform target;
    [SerializeField] string tag;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        FindTarget();
    }
    void FindTarget()
    {
        if (plants.Count > 0 && target == null)
            target = plants[Random.Range(0, plants.Count)];
        if (target != null)
            agent.SetDestination(target.position);
        else
            agent.SetDestination(transform.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        //if ((1 << other.gameObject.layer) == layer)
        if (other.CompareTag(tag))
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
