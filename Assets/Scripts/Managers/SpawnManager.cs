using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

   [SerializeField] private List<Transform> _spawnPoints;  
    /// <param name="points"></param>
    public void SetSpawnPoints(List<Transform> points)
    {
        _spawnPoints = points;
    }
    public Transform GetRandomSpawnPoint()
    {

        if (_spawnPoints == null || _spawnPoints.Count == 0)
        {
            Debug.LogError("Spawn points are not set or empty.");
            return null; 
        }

        return _spawnPoints[Random.Range(0, _spawnPoints.Count)];
    }
}
