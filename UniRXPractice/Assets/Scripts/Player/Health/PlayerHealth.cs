using UniRx;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    public ReactiveProperty<int> CurrentHealth { get; private set; }

    void Awake() => CurrentHealth = new ReactiveProperty<int>(maxHealth);
    public void TakeDamage(int damage)
    {
        CurrentHealth.Value -= damage;
        if (CurrentHealth.Value <= 0)
            Die();
    }
    public void Die()
    {
        Destroy(gameObject);
        GameManager.Instance.SetButtom();
    }
}