using UniRx;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinCounterUI : MonoBehaviour
{
   [SerializeField] private CoinCollector coinCollector;
   [SerializeField] private TextMeshProUGUI coinCounterText;

    void Start()
    {
        coinCollector.CollectedCoins
            .Subscribe(coins =>
            {
                coinCounterText.text = "Собрано монет: " + coins;
            })
            .AddTo(this); 
    }
}