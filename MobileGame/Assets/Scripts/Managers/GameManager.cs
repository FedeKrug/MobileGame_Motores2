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


	
}
