
using UnityEngine;
using UniRx;

public class CoinCollector : MonoBehaviour
{
    public ReactiveProperty<int> CollectedCoins { get; private set; }
    public ReactiveCommand CollectCoinCommand { get; private set; }

    [SerializeField] private int _coinOnScene;

    void Awake()
    {
        CollectedCoins = new ReactiveProperty<int>();
        CollectCoinCommand = new ReactiveCommand();
        CollectCoinCommand.Subscribe(_ => CollectCoin());
    }
    void CollectCoin()
    {
        CollectedCoins.Value++;
        if (CollectedCoins.Value == _coinOnScene)
            GameManager.Instance.SetButtom(); 
    }
}
