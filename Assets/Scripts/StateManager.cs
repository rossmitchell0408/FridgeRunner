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
        public const int Win = 2;
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

    public void PopToState(int state)
    {
        if(gameState.Contains(state))
        {
            Debug.Log("Popping to state: " + state.ToString());
            while (gameState.Count >= 0)
            {
                Debug.Log("Top state is: " + gameState.Peek());

                if ((int)gameState.Peek() == state)
                {
                    Debug.Log("Found it");
                    systemManager.RefreshState();
                    return;
                }

                Debug.Log("Popping top state");
                gameState.Pop();
            }

            Debug.Log("Could not pop to state. Returning to title");
            gameState.Push(GameState.Title);

        }
    }
}