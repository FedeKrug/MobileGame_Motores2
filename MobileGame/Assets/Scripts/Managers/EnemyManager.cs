using UnityEngine;

public class EnemyManager : MonoBehaviour
{
	/// <summary>
	/// La idea es usar un manejador de enemy counters para setear la variable de enemies in level (bool) (EnemyManager)
	/// </summary>
	#region Singleton
	public static EnemyManager instance;

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

	[SerializeField] private EnemyCounter[] _enemyCounters;
	public EnemyCounter activeCounter;

	private void Update()
	{
		for (int i = 0; i < _enemyCounters.Length; i++)
		{
			if (_enemyCounters[i].playerInCounter)
			{
				_enemyCounters[i] = activeCounter;
			}
		}
	}


}