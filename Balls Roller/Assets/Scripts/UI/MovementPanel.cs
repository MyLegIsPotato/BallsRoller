using ModestTree;
using System;
using UnityEngine;
using UnityEngine.UI;

public class MovementPanel : MonoBehaviour
{
    public Action ButtonUp_Clicked;
    public Action ButtonDown_Clicked;
    public Action ButtonLeft_Clicked;
    public Action ButtonRight_Clicked;

    [SerializeField]
    private Button buttonUp;
    [SerializeField]
    private Button buttonDown;
    [SerializeField]
    private Button buttonLeft;
    [SerializeField]
    private Button buttonRight;

    private void Start()
    {
        Assert.IsNotNull(buttonUp, "ButtonUp is not assigned in the inspector");
        Assert.IsNotNull(buttonDown, "ButtonDown is not assigned in the inspector");
        Assert.IsNotNull(buttonLeft, "ButtonLeft is not assigned in the inspector");
        Assert.IsNotNull(buttonRight, "ButtonRight is not assigned in the inspector");

        buttonUp.onClick.AddListener(() => ButtonUp_Clicked?.Invoke());
        buttonDown.onClick.AddListener(() => ButtonDown_Clicked?.Invoke());
        buttonLeft.onClick.AddListener(() => ButtonLeft_Clicked?.Invoke());
        buttonRight.onClick.AddListener(() => ButtonRight_Clicked?.Invoke());
    }
}
