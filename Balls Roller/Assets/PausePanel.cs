using System;
using UnityEngine;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    [SerializeField]
    private Button playButton;
    [SerializeField]
    private Button resumeButton;

    public Action OnPlayButtonClicked;
    public Action OnResumeButtonClicked;

    private void Awake()
    {
        playButton.onClick.AddListener(() => OnPlayButtonClicked?.Invoke());
        resumeButton.onClick.AddListener(() => OnResumeButtonClicked?.Invoke());
    }

    public void SetGameState(GameState state)
    {
        switch (state)
        {
            case GameState.Prespawn:
                playButton.interactable = true;
                resumeButton.interactable = false;
                break;
            case GameState.Paused:
                playButton.interactable = false;
                resumeButton.interactable = true;
                break;
        }
    }
}
