using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class FinishGameScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _goalText;
    [SerializeField, TextArea(3,5)] private string _winMessage, _looseMessage;
    [SerializeField] private GameObject _goalPanel;

    //TODO: Definir playerWon a partir del EnemyCounter
    public bool playerWon;

    public void GameOver()
	{
        _goalPanel.SetActive(true);
        _goalText.text = playerWon ? _winMessage : _looseMessage;
	}
}
