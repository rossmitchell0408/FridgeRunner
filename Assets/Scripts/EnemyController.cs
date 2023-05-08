using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private Rigidbody rBod;
    [SerializeField]
    private Collider sightCollider;
    [SerializeField]
    private bool isSeeingTarget;
    [SerializeField]
    private GameObject target;


    [SerializeField]
    private NavMeshAgent agent;


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
        if (target == null)
        {
            return;
        }

        agent.SetDestination(target.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isSeeingTarget = true;
            target = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isSeeingTarget = false;
            target = null;
        }
    }

}
