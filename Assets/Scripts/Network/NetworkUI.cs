using System.Collections.Generic;
using System.Text;
using TMPro;
using Unity.Netcode;
using Unity.Services.Lobbies.Models;
using UnityEngine;
using UnityEngine.UI;

public class NetworkUI : MonoBehaviour
{
    [SerializeField] private Button _hostButton;
    [SerializeField] private Button _joinButton;

    private void Start()
    {
        // Add listeners to the buttons
        _hostButton.onClick.AddListener(()=> { StartHost(); Hide();});
        _joinButton.onClick.AddListener(() => { StartClient(); Hide();});
    }
    private void StartHost()
    {
        NetworkManager.Singleton.StartHost();
    }

    private void StartClient()
    {
        NetworkManager.Singleton.StartClient();
    }
    void Hide()
    {
        _hostButton.gameObject.SetActive(false);
        _joinButton.gameObject.SetActive(false);
    }
}
