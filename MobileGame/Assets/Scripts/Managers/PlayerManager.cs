using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	public static PlayerManager instance;

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
}


