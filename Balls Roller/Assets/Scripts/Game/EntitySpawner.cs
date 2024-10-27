using ModestTree;
using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    [SerializeField]
    private int spawnInterval = 3000;
    [SerializeField]
    private GameObject entityPrefab;
    [SerializeField]
    private BoxCollider spawnArea;

    private void Awake()
    {
        Assert.IsNotNull(entityPrefab, "EntityPrefab is not assigned in the inspector");
        InvokeRepeating(nameof(SpawnAtRandomTransform), 0, spawnInterval / 1000f);
    }

    private void SpawnAtRandomTransform()
    {
        Vector3 position = new Vector3(
            Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x),
            Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y),
            Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z)
        );
        Instantiate(entityPrefab, position, Quaternion.identity);
    }
}