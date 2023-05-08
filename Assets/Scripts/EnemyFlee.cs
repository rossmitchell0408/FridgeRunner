using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFlee : MonoBehaviour
{
    private Rigidbody rBod;
    [SerializeField]
    private Collider sightCollider;
    [SerializeField]
    private bool isSeeingTarget;


    [SerializeField]
    private NavMeshAgent agent;
    [SerializeField]
    private Transform chaser;


    // Start is called before the first frame update
    void Start()
    {
        rBod = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (!isSeeingTarget)
        {
            return;
        }
        if (chaser == null)
        {
            return;
        }

        Vector3 direction = (chaser.position - transform.position).normalized;
        agent.SetDestination(transform.position - direction);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isSeeingTarget = true;
            chaser = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isSeeingTarget = false;
            chaser = null;
        }
    }

}
