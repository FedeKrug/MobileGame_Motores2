using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class FinishGameScreen : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _goalText;
	[SerializeField, TextArea(3, 5)] private string _winMessage, _looseMessage;
	[SerializeField] private GameObject _goalPanel;
	[SerializeField] private bool _lastLevel;
	[SerializeField] private GameObject _lastLevelStuff, _normalLevelStuff;


	//TODO: Definir playerWon a partir del EnemyCounter

	public static FinishGameScreen instance;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}
	public void GameOver(bool playerWon)
	{
		_lastLevelStuff.SetActive(_lastLevel);
		_normalLevelStuff.SetActive(!_lastLevel);

		_goalPanel.SetActive(true);
		_goalText.text = playerWon ? _winMessage : _looseMessage;
	}
}
