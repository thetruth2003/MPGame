using Unity.Netcode;
using UnityEngine;

/// <summary>
/// Handles the knockback effect for players in a networked environment using collision detection.
/// </summary>
public class NetworkKnockbackObject : NetworkBehaviour
{
    [Header("Knockback Settings")]
    [SerializeField] private float knockbackForce = 10f; // The force applied to knockback players

    /// <summary>
    /// Triggered when a collision is detected with this object.
    /// </summary>
    /// <param name="collision">Details about the collision.</param>
    private void OnCollisionEnter(Collision collision)
    {
        if (!IsServer) return; // Ensure the logic runs only on the server

        if (collision.collider.CompareTag("Player"))
        {
            NetworkObject playerNetworkObject = collision.collider.GetComponent<NetworkObject>();
            if (playerNetworkObject != null)
            {
                ApplyKnockbackToPlayer(playerNetworkObject, collision.contacts[0].point);
                Debug.Log("Player KnockOut");
            }
        }
    }

    /// <summary>
    /// Applies knockback to the player object on the server.
    /// </summary>
    /// <param name="playerNetworkObject">The player's network object.</param>
    /// <param name="contactPoint">The point of contact where the collision occurred.</param>
    private void ApplyKnockbackToPlayer(NetworkObject playerNetworkObject, Vector3 contactPoint)
    {
        Rigidbody playerRigidbody = playerNetworkObject.GetComponent<Rigidbody>();
        if (playerRigidbody != null)
        {
            // Calculate knockback direction (away from the contact point)
            Vector3 knockbackDirection = (playerRigidbody.position - contactPoint).normalized;

            // Apply the knockback force to the player's rigidbody
            playerRigidbody.AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);

            // Notify clients of the knockback effect (optional for visual effects)
            NotifyClientsOfKnockback(playerNetworkObject.NetworkObjectId, knockbackDirection * knockbackForce);
        }
    }

    /// <summary>
    /// Sends knockback information to clients for optional effects.
    /// </summary>
    /// <param name="playerNetworkObjectId">The ID of the player being knocked back.</param>
    /// <param name="appliedForce">The force applied to the player.</param>
    private void NotifyClientsOfKnockback(ulong playerNetworkObjectId, Vector3 appliedForce)
    {
        KnockbackClientRpc(playerNetworkObjectId, appliedForce);
    }

    /// <summary>
    /// Client-side function for handling knockback effects.
    /// </summary>
    /// <param name="playerNetworkObjectId">The ID of the player being knocked back.</param>
    /// <param name="appliedForce">The force applied to the player.</param>
    [ClientRpc]
    private void KnockbackClientRpc(ulong playerNetworkObjectId, Vector3 appliedForce)
    {
        // Client-specific logic for knockback effects (e.g., visual or audio)
        Debug.Log($"Player {playerNetworkObjectId} knocked back with force {appliedForce}");
    }
}
