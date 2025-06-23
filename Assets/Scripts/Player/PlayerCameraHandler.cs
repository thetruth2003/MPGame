using Unity.Netcode;
using UnityEngine;

public class PlayerCameraHandler : NetworkBehaviour
{
    [Header("Camera Settings")]
    [SerializeField] private Camera _playerCamera; 

    private void Start()
    {

        if (IsOwner)
        {
            ActivateCamera();
        }
        else
        {
            DeactivateCamera();
        }
    }


    private void ActivateCamera()
    {
        if (_playerCamera != null)
        {
            _playerCamera.enabled = true; 
        }
    }


    private void DeactivateCamera()
    {
        if (_playerCamera != null)
        {
            _playerCamera.enabled = false; 
        }
    }
}
