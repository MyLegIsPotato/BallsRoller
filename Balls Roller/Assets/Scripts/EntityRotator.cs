using UnityEngine;

public class EntityRotator : MonoBehaviour
{
    [SerializeField]
    Vector3 rotationSpeed;

    private void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
