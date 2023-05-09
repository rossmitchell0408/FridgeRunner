using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    [SerializeField]
    private StateManager stateManager;

    [SerializeField]
    private Button playButton;
    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.RemoveAllListeners();
        playButton.onClick.AddListener(delegate { stateManager.PushState(StateManager.GameState.Game); });
    }
}
