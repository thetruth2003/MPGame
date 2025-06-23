using Unity.Netcode;
using UnityEngine;

public abstract class AbstractPlayer : NetworkBehaviour
{
    public string playerName;  
    public int health;  


    /// <summary>
    /// Abstract method to initialize player-specific data
    /// </summary>
    public abstract void InitializePlayer();

    /// <summary>
    /// </summary>
    /// <param name="spawnPoint"></param> 
    public abstract void SpawnAtPoint(Transform spawnPoint);
}
