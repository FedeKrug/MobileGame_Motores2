using UnityEngine;

public abstract class MagicProjectile : MonoBehaviour
{
	[SerializeField] protected float _speed = 10f, _maxDistance = 500f, _currentDistance = 0f;

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

    public static void TurnOnOff(MagicProjectile p, bool active = true)
    {
        if (active) p.Reset();
        p.gameObject.SetActive(active);
    }
}