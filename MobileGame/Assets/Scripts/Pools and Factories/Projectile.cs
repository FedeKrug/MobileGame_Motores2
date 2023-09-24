using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed = 10f, _maxDistance = 500f, _currentDistance = 0f;
    void Update()
    {
        float distanceToTravel = _speed * Time.deltaTime;
        transform.position += transform.forward * distanceToTravel;
        _currentDistance += distanceToTravel;
        if(_currentDistance > _maxDistance)
        {
            ProjectileFactory.Instance.ReturnProjectile(this);
        }
    }

    private void Reset()
    {
        _currentDistance = 0;
    }

    public static void TurnOnOff(Projectile p, bool active = true)
    {
        if(active) p.Reset();
        p.gameObject.SetActive(active);
    }
}
