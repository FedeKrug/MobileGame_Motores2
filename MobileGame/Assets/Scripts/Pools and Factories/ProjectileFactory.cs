using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFactory : MonoBehaviour
{

    public MagicProjectile projectilePrefab;
    public int stock = 10;
    //Esto imo deberia tener otro nombre, es la cantidad de proyectiles
    //que crea per request del pool es decir que si el pool necesta 1, la factory crea 10 y tiene 9 extras

    public ObjectPool<MagicProjectile> pool;
    //este projectile de aca deberia ser generico

    #region Singleton
    public static ProjectileFactory Instance;

    void Awake()
    {
        if (Instance == null)
		{
            Instance = this;
		}
        else
		{
            Destroy(gameObject);
		}

        pool = new ObjectPool<MagicProjectile>(projectileCreator, MagicProjectile.TurnOnOff ,stock);

    }

    #endregion


    public MagicProjectile projectileCreator()

    {
        return Instantiate(projectilePrefab);
    }


    public void ReturnProjectile(MagicProjectile p)

    {
        pool.ReturnObject(p);
    }
}
