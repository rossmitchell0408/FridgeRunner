using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupCharacter : MonoBehaviour
{
    private enum Controller
    {
        PLAYER,
        ENEMY
    }

    [SerializeField]
    Controller controller;

    // Start is called before the first frame update
    void Start()
    {
        if (controller == Controller.PLAYER)
        {
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
