using UnityEngine;

public class EnemyManager : MonoBehaviour
{
	/// <summary>
	/// La idea es usar un manejador de enemy counters para setear la variable de enemies in level (bool) (EnemyManager)
	/// </summary>

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


	[SerializeField] private EnemyCounter[] _enemyCounters;



}