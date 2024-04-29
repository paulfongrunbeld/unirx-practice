using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
	private static GameManager _instance;
	[SerializeField] private Button _buttom;
	private void Start() => _buttom.gameObject.SetActive(false);
	private void Awake() => _instance = this;
	public static GameManager Instance
	{
		get
		{
			if (_instance == null)
			{
				GameObject singletonObject = new GameObject("GameManager");
				_instance = singletonObject.AddComponent<GameManager>();
			}
			return _instance;
		}
	}
	public void CloseButtom()
	{
		_buttom.gameObject.SetActive(false);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	public void SetButtom() => _buttom.gameObject.SetActive(true);
}
