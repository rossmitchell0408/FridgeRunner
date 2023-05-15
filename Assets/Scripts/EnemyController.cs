using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private enum ChaseMode
    {
        IDLE = -1,
        CHASE = 0,
        FLEE = 1
    }

    [SerializeField]
    private GameManager gameManager;

    private Rigidbody rBod;
    [SerializeField]
    private Collider sightCollider;
    [SerializeField]
    private Collider contactCollider;
    //[SerializeField]
    //private bool isSeeingTarget;
    [SerializeField]
    private Transform target;


    [SerializeField]
    private NavMeshAgent agent;

    [SerializeField]
    private ChaseMode chaseMode;


    // Start is called before the first frame update
    void Start()
    {
        rBod = GetComponent<Rigidbody>();
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        if (gameManager == null)
        {
            StartCoroutine(LateStart(1));
        }

    }
    
    IEnumerator LateStart(float delaySeconds)
        {
            yield return new WaitForSeconds(delaySeconds);
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        //if (!isSeeingTarget)
        //{
        //    return;
        //}
        if (target == null)
        {
            return;
        }

        switch (chaseMode)
        {
            case ChaseMode.IDLE:
                break;
            case ChaseMode.CHASE:
                agent.SetDestination(target.position);
                break;
            case ChaseMode.FLEE:
                Vector3 direction = (target.position - transform.position).normalized;
                agent.SetDestination(transform.position - direction);
                break;
            default:
                break;
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //isSeeingTarget = true;
            target = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //isSeeingTarget = false;
            target = null;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Destroy(gameObject);
            switch (chaseMode)
            {
                case ChaseMode.IDLE:
                    break;
                case ChaseMode.CHASE:
                    Debug.Log("Got you!");
                    break;
                case ChaseMode.FLEE:
                    Debug.Log("You got me!");
                    gameManager.RemoveTarget(gameObject);
                    Destroy(gameObject);
                    break;
                default:
                    break;
            }
        }
    }

}
