using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class AudioSettings : MonoBehaviour
{
    public ReactiveProperty<bool> IsSoundEnabled { get; private set; }
    public ReactiveProperty<bool> IsMusicEnabled { get; private set; }

    private void Awake()
    {
        IsSoundEnabled = new ReactiveProperty<bool>(true);
        IsMusicEnabled = new ReactiveProperty<bool>(true);
    }
}
