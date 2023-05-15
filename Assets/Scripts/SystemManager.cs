using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemManager : MonoBehaviour
{
    [SerializeField]
    private GameObject titlePanel;
    [SerializeField]
    private GameObject game;
    [SerializeField]
    private GameObject winPanel;


    void Start()
    {
        RefreshState();
    }

    public void RefreshState()
    {
        titlePanel.SetActive(false);
        game.SetActive(false);
        winPanel.SetActive(false);

        switch (StateManager.gameState.Peek())
        {
            case StateManager.GameState.Title:
                titlePanel.SetActive(true);
                break;
            case StateManager.GameState.Game:
                game.SetActive(true);
                break;
            case StateManager.GameState.Win:
                winPanel.SetActive(true);
                break;
            default:
                break;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}