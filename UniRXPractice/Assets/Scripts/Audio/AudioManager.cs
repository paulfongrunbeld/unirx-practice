using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSettings audioSettings;
    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioSource musicSource;

    private void Start()
    {
        audioSettings.IsSoundEnabled
            .Subscribe(isEnabled => soundSource.enabled = isEnabled)
            .AddTo(this);

        audioSettings.IsMusicEnabled
            .Subscribe(isEnabled => musicSource.enabled = isEnabled)
            .AddTo(this);
    }
}
