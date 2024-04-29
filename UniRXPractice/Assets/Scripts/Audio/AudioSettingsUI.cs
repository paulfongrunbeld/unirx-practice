using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

public class AudioSettingsUI : MonoBehaviour
{
    [SerializeField] private AudioSettings audioSettings;
    [SerializeField] private Toggle soundToggle;
    [SerializeField] private Toggle musicToggle;

    private void Start()
    {
        soundToggle.isOn = audioSettings.IsSoundEnabled.Value;
        musicToggle.isOn = audioSettings.IsMusicEnabled.Value;

        soundToggle.OnValueChangedAsObservable()
            .Subscribe(value => audioSettings.IsSoundEnabled.Value = value)
            .AddTo(this);

        musicToggle.OnValueChangedAsObservable()
            .Subscribe(value => audioSettings.IsMusicEnabled.Value = value)
            .AddTo(this);
    }
}