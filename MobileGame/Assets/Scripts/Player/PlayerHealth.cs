using UnityEngine;
using System.Collections;


public class PlayerHealth : MonoBehaviour
{
	private float _maxHealth;
	public static PlayerHealth instance;
	[SerializeField] private float _timeOfInvulnerability= 0.2f;
	[SerializeField] private int _playerLayer = 7;
	[SerializeField] private int _invecibilityLayer = 9;

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
	public float MaxHealth
	{
		get => _maxHealth;
		set => _maxHealth = value;
	}

	private void Start()
	{
		_maxHealth = DataManager.instance.data.life;
		DataManager.instance.data.life = _maxHealth;
	}


	public void TakeDamage(float damage)
	{
		DataManager.instance.data.life -= damage;
		StartCoroutine(CO_useDamageEffect());
		CheckDeath();

	}

	private void CheckDeath()
	{
		if (DataManager.instance.data.life <= 0)
		{
			//Die
			Debug.Log("Dead...");
		FinishGameScreen.instance.GameOver(false);
		}
		UIManager.instance.UpdateLife();
	}

	public void IncreaseHealth(float increaseAmount)
	{
		DataManager.instance.data.life += increaseAmount;
		if (DataManager.instance.data.life >= _maxHealth)
		{
			DataManager.instance.data.life = _maxHealth;
		}
		UIManager.instance.UpdateLife();
	}

	private IEnumerator CO_useDamageEffect()
	{
		gameObject.layer = _invecibilityLayer;
		yield return new WaitForSeconds(_timeOfInvulnerability);
		gameObject.layer = _playerLayer;
	}

}
