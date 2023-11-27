using TMPro;
using UnityEngine.UI;
using UnityEngine;

[DefaultExecutionOrder(-10)]
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

	private SaveData _saveData;
	[SerializeField] private TextMeshProUGUI _scoreText;
	[SerializeField] private Image _healthBar;

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
		_saveData = DataManager.instance.data;
		_scoreText.text = string.Format("Coins: {0:000}", _saveData.coins);
	}
	public void TakeCoins(int coinAmount)
	{
		_saveData.coins += coinAmount;
		UpdateScoreText();
	}
	public void UpdateScoreText()
	{
		if (_saveData.coins <= 0)
		{
			_saveData.coins = 0;
		}
		_scoreText.text = string.Format("Coins: {0:000}", _saveData.coins);
	}
	public void UpdateLife()
	{
		if (_saveData.life <= 0)
		{
			_saveData.life = 0;
		}
		_healthBar.fillAmount = _saveData.life / GameManager.instance.PlayerHealth.MaxHealth;
	}

	public void LoadDataUI()
	{
		UpdateLife();
		UpdateScoreText();
		GameManager.instance.UpdateCoinsAmountSO();
	}
}
