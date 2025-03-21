using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _platforms; // Array to hold multiple platform prefabs

    [SerializeField]
    private Transform _player; // Reference to the player

    [SerializeField]
    private float _spawnDistanceAbovePlayer = 10f; // Distance above the player to spawn platforms

    [SerializeField]
    private float _minimumSpawnTime;

    [SerializeField]
    private float _maximumSpawnTime;

    [SerializeField]
    private float _cleanupDistanceBelowPlayer = 15f; // Distance below the player to destroy platforms

    private float _timeUntilSpawn;
    private List<GameObject> _spawnedPlatforms = new List<GameObject>(); // Track spawned platforms

    void Awake()
    {
        SetTimeUntilSpawn();
    }

    void Update()
    {
        _timeUntilSpawn -= Time.deltaTime;

        if (_timeUntilSpawn <= 0)
        {
            SpawnPlatform();
            SetTimeUntilSpawn();
        }

        CleanupPlatforms();
    }

    private void SetTimeUntilSpawn()
    {
        _timeUntilSpawn = Random.Range(_minimumSpawnTime, _maximumSpawnTime);
    }

    private void SpawnPlatform()
    {
        if (_platforms.Length > 0)
        {
            int randomIndex = Random.Range(0, _platforms.Length);
            GameObject selectedPlatform = _platforms[randomIndex];

            Vector3 spawnPosition = new Vector3(
                Random.Range(-5f, 5f), // Random horizontal offset
                _player.position.y + _spawnDistanceAbovePlayer, // Above the player
                0f // Keep Z-axis at 0
            );

            GameObject platformInstance = Instantiate(
                selectedPlatform,
                spawnPosition,
                Quaternion.identity
            );

            // Add the spawned platform to the list
            _spawnedPlatforms.Add(platformInstance);

            // If the platform has a MovingPlatform script, set its points dynamically
            MovingPlatform movingPlatform = platformInstance.GetComponent<MovingPlatform>();
            if (movingPlatform != null)
            {
                float horizontalOffset = Random.Range(2f, 5f); // Random horizontal distance for movement
                movingPlatform.pointA = spawnPosition + new Vector3(-horizontalOffset, 0f, 0f);
                movingPlatform.pointB = spawnPosition + new Vector3(horizontalOffset, 0f, 0f);
            }
        }
        else
        {
            Debug.LogWarning("No platforms assigned to the PlatformSpawner!");
        }
    }

    private void CleanupPlatforms()
    {
        // Iterate through the list of spawned platforms
        for (int i = _spawnedPlatforms.Count - 1; i >= 0; i--)
        {
            GameObject platform = _spawnedPlatforms[i];

            // Check if the platform is null (already destroyed)
            if (platform == null)
            {
                _spawnedPlatforms.RemoveAt(i);
                continue;
            }

            // Check if the platform is far below the player
            if (platform.transform.position.y < _player.position.y - _cleanupDistanceBelowPlayer)
            {
                // Destroy the platform and remove it from the list
                Destroy(platform);
                _spawnedPlatforms.RemoveAt(i);
            }
        }
    }
}
