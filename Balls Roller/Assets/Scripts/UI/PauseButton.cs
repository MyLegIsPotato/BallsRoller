using System;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    [SerializeField]
    private Button button;

    public Action OnPauseButtonClicked;

    private void Awake()
    {
        button.onClick.AddListener(() => OnPauseButtonClicked?.Invoke());
    }
}
