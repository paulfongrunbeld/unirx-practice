using UnityEngine;
using UnityEngine.UI;
using UniRx;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TimerUI : MonoBehaviour
{
    [SerializeField] private Timer timer;
    private TextMeshProUGUI timerText;

    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();

        timer.RemainingTime.Subscribe(time =>
        {
            timerText.text = "�������� �������: " + time.ToString("F2");
        }).AddTo(this); 

        timer.OnTimeExpired.Subscribe(_ =>
        {
            timerText.text = "����� �����!";
           
        }).AddTo(this); 
    }
}