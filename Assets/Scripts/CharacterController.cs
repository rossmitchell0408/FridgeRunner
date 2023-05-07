using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Rigidbody rBod;
    [SerializeField]
    private float moveForce;
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float turnSpeed;
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
    
    void Move()
    {
        if (rBod.velocity.magnitude <= maxSpeed)
        {
            rBod.AddForce(transform.forward * Input.GetAxis("Vertical") * moveForce * Time.fixedDeltaTime);
        }

        transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.fixedDeltaTime, 0);

        //Debug.Log(rBod.velocity.magnitude);
    }
}
