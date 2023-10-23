using UnityEngine;

public class GameManager : MonoBehaviour
{
	#region singleton
	public static GameManager instance;
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

	[SerializeField] private Transform _playerPos;
	[SerializeField] private PlayerStatsSO _playerStats;
	[SerializeField] private IntSO _coinsAmount;
	[SerializeField] private SPAtkBarCircle _spAttackRef;
	[SerializeField] private PlayerCollector _playerCollector;
	public PlayerStatsSO PlayerStats
	{
		get => _playerStats;
		set => _playerStats = value;
	}
	public Transform PlayerPos
	{
		get => _playerPos;
		set => _playerPos = value;
	}
	public SPAtkBarCircle SpAttackRef
	{
		get => _spAttackRef;
		set => _spAttackRef = value;
	}
	public PlayerCollector PlayerCollector
	{
		get => _playerCollector;
		set => _playerCollector = value;
	}

	private void Start()
	{
		UpdateCoinsAmountSO();
	}
	public void UpdateCoinsAmountSO()
	{
		_coinsAmount.value = UIManager.instance.Score;
	}
}
