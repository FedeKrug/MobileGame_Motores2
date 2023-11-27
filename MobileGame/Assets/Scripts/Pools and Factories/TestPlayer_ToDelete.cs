using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer_ToDelete : MonoBehaviour
{
    [SerializeField] private Transform _shootingPoint;
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            var p = ProjectileFactory.Instance.pool.GetObject();
            p.transform.SetPositionAndRotation(transform.position, Quaternion.identity);
        }
    }
}
