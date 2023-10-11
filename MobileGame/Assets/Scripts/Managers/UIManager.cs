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

	[SerializeField] private int _score;
	[SerializeField] private TextMeshProUGUI _scoreText;

	private void Start()
	{
		_scoreText.text = string.Format("Coins: {0:000}", _score);
	}

}