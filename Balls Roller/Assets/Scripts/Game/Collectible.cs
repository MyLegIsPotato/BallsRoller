using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var collector = other.GetComponent<Collector>();
        if (collector == null)
            return;

        collector.Collect(this);
        Destroy(gameObject);
    }
}
