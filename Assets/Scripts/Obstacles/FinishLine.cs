using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private UIManager _uiManager;

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();

        if (player != null)
        {
            _uiManager.DisplayWinner(player.playerName);
        }
    }
}
