using UnityEngine;

public abstract class MagicProjectile : MonoBehaviour
{
	[SerializeField] protected float _speed = 10f, _maxDistance = 500f, _currentDistance = 0f;
    [SerializeField] protected float _damage = 4;
    void Update()
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

	private void OnTriggerEnter(Collider other)
	{
        Enemy enemyRef = other.gameObject.GetComponent<Enemy>();

        if (enemyRef)
		{
            enemyRef.TakeDamage(_damage);
            Reset();
		}
	}

	public static void TurnOnOff(MagicProjectile p, bool active = true)
    {
        if (active) p.Reset();
        p.gameObject.SetActive(active);
    }
}