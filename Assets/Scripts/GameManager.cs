using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private StateManager stateManager;

    [SerializeField]
    private List<GameObject> targets;
    [SerializeField]
    private List<GameObject> enemies;
    [SerializeField]
    private List<GameObject> players;

    void Start()
    {
        targets = GameObject.FindGameObjectsWithTag("Target").ToList<GameObject>();
    }

    void FixedUpdate()
    {
        //if (targets.Count <= 0)
        //{
        //    stateManager.PushState(StateManager.GameState.Win);
        //}
    }

    public void RemoveTarget(GameObject target)
    {
        if (!targets.Contains(target))
        {
            Debug.Log("Game Manager could not find " + target.name + " to remove.");
            return;
        }

        targets.Remove(target);

        if (targets.Count <= 0)
        {
            stateManager.PushState(StateManager.GameState.Win);
        }
    }
}
