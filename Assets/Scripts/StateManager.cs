using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    [SerializeField]
    SystemManager systemManager;

    static public class GameState
    {
        public const int Title = 0;
        public const int Game = 1;
    }

    static public Stack gameState = new Stack();


    void Awake()
    {
        gameState.Push(GameState.Title);
    }

    public void PushState(int state)
    {
        gameState.Push(state);
        systemManager.RefreshState();
    }

    public void PopState()
    {
        gameState.Pop();
        systemManager.RefreshState();
    }
}