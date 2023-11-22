using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	private float _maxHealth;
	public static PlayerHealth instance;


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
		_maxHealth = UIManager.instance.SaveData.life;
		UIManager.instance.SaveData.life = _maxHealth;
	}


	public void TakeDamage(float damage)
	{
		UIManager.instance.SaveData.life -= damage;

		CheckDeath();

	}

	private void CheckDeath()
	{
		if (UIManager.instance.SaveData.life <= 0)
		{
			//Die
			Debug.Log("Dead...");
		}
		UIManager.instance.UpdateLife();
		FinishGameScreen.instance.GameOver(false);
	}

	public void IncreaseHealth(float increaseAmount)
	{
		UIManager.instance.SaveData.life += increaseAmount;
		if (UIManager.instance.SaveData.life >= _maxHealth)
		{
			UIManager.instance.SaveData.life = _maxHealth;
		}
		UIManager.instance.UpdateLife();
	}
}
