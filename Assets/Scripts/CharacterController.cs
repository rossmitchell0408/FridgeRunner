using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // temp
    [SerializeField]
    private StateManager stateManager;

    private Rigidbody rBod;
    [SerializeField]
    private float acceleration;
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

        // temp
        if (Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("Popping");
            stateManager.PopState();
        }
    }
    
    void Move()
    {
        if (rBod.velocity.magnitude <= maxSpeed)
        {
            rBod.AddForce(transform.forward * Input.GetAxis("Vertical") * acceleration * Time.fixedDeltaTime);
        }

        transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.fixedDeltaTime, 0);

        if (Input.GetAxis("Horizontal") == 0f)
        {
            transform.Rotate(0, 0, 0);
        }

        //Debug.Log(rBod.velocity.magnitude);
    }
}
