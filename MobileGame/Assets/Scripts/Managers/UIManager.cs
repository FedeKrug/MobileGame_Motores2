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

	[SerializeField] private IntSO _scoreCoins;
	[SerializeField] private TextMeshProUGUI _scoreText;

	private void Start()
	{
		_scoreText.text = string.Format("Coins: {0:000}", _scoreCoins.value);
	}
	public void TakeCoins(int coinAmount)
	{
		_scoreCoins.value+= coinAmount;
		UpdateScoreText();
	}
	private void UpdateScoreText()
	{
		_scoreText.text = string.Format("Coins: {0:000}", _scoreCoins.value);
	}
}