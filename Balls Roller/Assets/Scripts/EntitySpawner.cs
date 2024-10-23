using ModestTree;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    [SerializeField]
    private int spawnInterval = 3000;

    [SerializeField]
    private GameObject entityPrefab;
    [SerializeField]
    private List<Transform> spawnTransforms = new List<Transform>();

    private void Awake()
    {
        Assert.IsNotNull(entityPrefab, "EntityPrefab is not assigned in the inspector");
        InvokeRepeating(nameof(SpawnAtRandomTransform), 0, spawnInterval / 1000f);
    }

    private void SpawnAtRandomTransform()
    {
        print("Spawning entity");
        int randomIndex = Random.Range(0, spawnTransforms.Count);
        Transform randomTransform = spawnTransforms[randomIndex];
        Instantiate(entityPrefab, randomTransform.position, randomTransform.rotation);
    }
}
