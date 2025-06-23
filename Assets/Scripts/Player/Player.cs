using UnityEngine;

public class Player : AbstractPlayer
{
    public override void InitializePlayer()
    {
        playerName = "Player" + Random.Range(1, 1000).ToString();
        health = 10;
    }
    public override void SpawnAtPoint(Transform spawnPoint)
    {
        transform.position = spawnPoint.position; 
        transform.rotation = spawnPoint.rotation;  
    }
}