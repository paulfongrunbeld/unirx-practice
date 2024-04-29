using UniRx;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private CoinCollector coinCollector;
	private void Start() => coinCollector = GameObject.FindGameObjectWithTag("Player").GetComponent<CoinCollector>();
	void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            coinCollector.CollectCoinCommand.Execute();
            SoundManager.Instance.PlaySound();
            Destroy(gameObject);
        }
    }
}