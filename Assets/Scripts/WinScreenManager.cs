using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreenManager : MonoBehaviour
{
    [SerializeField]
    private StateManager stateManager;

    [SerializeField]
    private Button replayButton;
    [SerializeField]
    private Button menuButton;
    // Start is called before the first frame update
    void Start()
    {
        replayButton.onClick.RemoveAllListeners();
        replayButton.onClick.AddListener(delegate { stateManager.PopState(); });

        menuButton.onClick.RemoveAllListeners();
        menuButton.onClick.AddListener(delegate { stateManager.PopToState(StateManager.GameState.Title); });
    }
}
