using TMPro;

using UnityEngine;

public class UIManager : MonoBehaviour
{
	#region Singleton
	public static UIManager instance;
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
	#endregion

	[SerializeField] private SaveData _saveData;
	[SerializeField] private TextMeshProUGUI _scoreText;

	public int Score
	{
		get => _saveData.coins;
		set => _saveData.coins = value;
	}
	public SaveData SaveData
	{
		get => _saveData;
		set => _saveData = value;
	}

	private void Start()
	{
		_scoreText.text = string.Format("Coins: {0:000}", _saveData.coins);
	}
	public void TakeCoins(int coinAmount)
	{
		_saveData.coins += coinAmount;
		UpdateScoreText();
	}
	public void UpdateScoreText()
	{
		_scoreText.text = string.Format("Coins: {0:000}", _saveData.coins);
	}

}