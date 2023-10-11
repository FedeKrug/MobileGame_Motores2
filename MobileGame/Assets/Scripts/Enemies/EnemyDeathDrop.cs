using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathDrop : MonoBehaviour
{
	[SerializeField] private int _minDropAmount, _maxDropAmount;
	[SerializeField] private GameObject [] _objectsToDrop;
	private Enemy _enemyRef;

	private void Start()
	{
		_enemyRef = GetComponentInParent<Enemy>();
	}

	public void DropObjects()
	{
		for (int i =0; i< Random.Range(_minDropAmount, _maxDropAmount); i++)
		{
			Instantiate(_objectsToDrop[Random.Range(0, _objectsToDrop.Length)], transform.position, transform.rotation);
		}
		_enemyRef.transform.DetachChildren();
	}

}
