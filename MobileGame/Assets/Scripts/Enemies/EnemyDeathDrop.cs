using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathDrop : MonoBehaviour
{
	[SerializeField] private int _minDropAmount, _maxDropAmount;
	[SerializeField] private GameObject [] _objectsToDrop;
	private EnemyHealth _enemyRef;

	private void Start()
	{
		_enemyRef = GetComponentInParent<EnemyHealth>();
	}

	public void DropObjects(Vector3 dropPosition)
	{
		for (int i =0; i< Random.Range(_minDropAmount, _maxDropAmount); i++)
		{
		//_enemyRef.transform.DetachChildren();
			Instantiate(_objectsToDrop[Random.Range(0, _objectsToDrop.Length)], dropPosition, transform.rotation);
			
		}
	}

}
