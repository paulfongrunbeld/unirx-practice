using UniRx;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private TextMeshProUGUI healthText;

    void Start()
    {
        playerHealth.CurrentHealth
            .Subscribe(health =>
            {
                healthText.text = "Health: " + health;
            })
            .AddTo(this); 
    }
}