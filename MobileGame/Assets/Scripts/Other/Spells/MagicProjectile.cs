using UnityEngine;

public abstract class MagicProjectile : MonoBehaviour
{
	[SerializeField] protected float _speed = 10f, _maxDistance = 500f, _currentDistance = 0f;
	[SerializeField] protected float _damage = 4;
	[SerializeField] protected ProjectileSoundEffect _effect;
	protected void Update()
	{
		float distanceToTravel = _speed * Time.deltaTime;
		transform.position += transform.forward * distanceToTravel;
		_currentDistance += distanceToTravel;
		if (_currentDistance > _maxDistance)
		{
			ProjectileFactory.instance.ReturnProjectile(this);
		}
	}

	public void Reset()
	{
		_currentDistance = 0;
	}

	protected virtual void OnTriggerEnter(Collider other)
	{
		EnemyHealth enemyRef = other.gameObject.GetComponent<EnemyHealth>();

		if (enemyRef)
		{
			enemyRef.TakeDamage(_damage);
			Reset();
			bool activedProjectile = false;
			TurnOnOff(this, activedProjectile);
		}
	}

	public static void TurnOnOff(MagicProjectile p, bool active = true)
	{
		if (active) p.Reset();
		p.gameObject.SetActive(active);
	}
}