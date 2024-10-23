using ModestTree;
using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private MovementPanel movementPanel;

    private Rigidbody rigidbody;

    private void Start()
    {
        Assert.IsNotNull(movementPanel, "MovementPanel is not assigned in the inspector");
        movementPanel.ButtonUp_Clicked += MoveUp;
        movementPanel.ButtonDown_Clicked += MoveDown;
        movementPanel.ButtonLeft_Clicked += MoveLeft;
        movementPanel.ButtonRight_Clicked += MoveRight;
        rigidbody = GetComponent<Rigidbody>();
    }

    private void MoveUp()
    {
        rigidbody.AddForce(Vector3.forward * speed);
    }

    private void MoveDown()
    {
        rigidbody.AddForce(Vector3.back * speed);
    }

    private void MoveLeft()
    {
        rigidbody.AddForce(Vector3.left * speed);
    }

    private void MoveRight()
    {
        rigidbody.AddForce(Vector3.right * speed);
    }
}
