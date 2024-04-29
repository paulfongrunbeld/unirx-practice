using System;
using UniRx;
using UnityEngine;


public class Timer : MonoBehaviour
{
    [SerializeField] private float gameTime = 60f; 
    [SerializeField] private float updateInterval = 1f; 

    private IDisposable timerSubscription;
    private IDisposable sampleSubscription;
    private float remainingTime;

    public ReactiveProperty<float> RemainingTime { get; private set; }
    public Subject<Unit> OnTimeExpired { get; private set; }

    [SerializeField] private PlayerHealth _playerHealth;

    void Awake()
    {
        RemainingTime = new ReactiveProperty<float>(gameTime);
        OnTimeExpired = new Subject<Unit>();
        _playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    void Start()
    {
        remainingTime = gameTime;

        timerSubscription = Observable.Timer(TimeSpan.FromSeconds(gameTime))
            .Subscribe(_ =>
            {
                OnTimeExpired.OnNext(Unit.Default);
            });

        sampleSubscription = Observable.Interval(TimeSpan.FromSeconds(updateInterval))
            .Sample(TimeSpan.FromSeconds(updateInterval))
            .Subscribe(_ =>
            {
                remainingTime -= updateInterval;
                RemainingTime.Value = remainingTime;

                if (remainingTime <= 0)
                {
                    OnTimeExpired.OnNext(Unit.Default);

					if (_playerHealth != null)
                        _playerHealth.Die();
					
                    GameManager.Instance.SetButtom();
                }
            });
    }
    void OnDestroy()
    {
        timerSubscription?.Dispose();
        sampleSubscription?.Dispose();
    }
}