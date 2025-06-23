using TMPro;
using UnityEngine;
using UnityEngine.UI; // For UI Text components

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _winText; 


    public void DisplayWinner(string playerName)
    {
        if (_winText != null)
        {
            _winText.text = $"{playerName} won!";
            Debug.Log($"{playerName} won!"); 
        }
    }
}
