using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFactory : MonoBehaviour
{
    public Projectile projectilePrefab;
    public int stock = 10;//Esto imo deberia tener otro nombre, es la cantidad de proyectiles que crea per request del pool es decir que si el pool necesta 1, la factory crea 10 y tiene 9 extras

    public ObjectPool<Projectile> pool;//este projectile de aca deberia ser generico

    #region Singleton
    public static ProjectileFactory Instance { get { return _instance; } }
    private static ProjectileFactory _instance; //porque estatizamos esta si la de arriba ya esta estatizada? O estatizar tambien tiene que ver con la "unicidad de  las cosas"
    void Start()
    {
        _instance = this;//No me acuerdo como hacer la redundancia de que destruya los extras
        pool = new ObjectPool<Projectile>(projectileCreator, Projectile.TurnOnOff ,stock);
    }

    #endregion

    void Update()
    {
    }

    public Projectile projectileCreator()
    {
        return Instantiate(projectilePrefab);
    }

    public void ReturnProjectile(Projectile p)
    {
        pool.ReturnObject(p);
    }
}
