using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, Collectable
{
	[SerializeField] private int _score;
	public void Collect()
	{
		UIManager.instance.TakeCoins(_score);
		Destroy(gameObject);
	}
}
