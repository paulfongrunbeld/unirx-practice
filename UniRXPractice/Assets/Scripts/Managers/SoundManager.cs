using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	[SerializeField] private AudioSource _audioSource;
	[SerializeField] private AudioClip _audioClip;

	private static SoundManager _instance;

	private void Start()
	{
		_audioSource = GetComponent<AudioSource>();
		_audioSource.clip = _audioClip;
	}
	public void PlaySound()
	{
		if (_audioSource.enabled)
			_audioSource.Play();
	}

	private void Awake() => _instance = this;

	public static SoundManager Instance
	{
		get
		{
			if (_instance == null)
			{
				GameObject singletonObject = new GameObject("SoundManager");
				_instance = singletonObject.AddComponent<SoundManager>();
			}
			return _instance;
		}
	}
}
