using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public /*abstract*/ class ObjectPool<obj>//Esto parece necesario para poder utilizar generics. El generic representa una CLASE (que esa clase in turn puede representa un objeto)
{
    private Func<obj> _factoryMethod = default; //Func es un delegado que devuelve algo (un solo item indica el out, no pide nada), el opuesto de Action que solo devuelve void
    private List<obj> _currentStock = new List<obj>();
    //Como comentario curioso, <T> no existe en este contexto (Func<T> tira error, lo mismo con la lista), solo OBJ. Lo que significa que solo puedo tener 1 tipo de generic por clase?

    private Action<obj,bool> _turnOnOffCallback = default;//Este es el TurnOnOff del projectile

    //Este es el constructor. Al ser una clase que NO existe en escena tengo que configurarle los valores que le pido cuando la cree con una clase que SI existe en escena
    public ObjectPool(Func<obj> factoryMethod,Action<obj,bool> callBack ,int initialStock = 1) //initial stock corresponde con el stock del factory. Es decir "cuantos voy a almacenar en mi lista" Por eso se usa para el for, agrego la cantidad que el factory le pasa
    {
        _factoryMethod = factoryMethod;
        _turnOnOffCallback = callBack;
        for (int i = 0; i < initialStock; i++)
        {
            obj T = _factoryMethod();// T representa el GameObject, en este caso projectile. _ factory method es el metodo qeu crea projectiles. Entonces, ese projectile que instancie ser agrega a mi stock actual
            _turnOnOffCallback(T,false);
            _currentStock.Add(T);
        }
    }
    public obj GetObject()
    {
        var result = default(obj);//de esta manera puedo hacer que result sea el obj que estoy trabajando en el momento
        if (_currentStock.Count > 0)//si hay algo en la lista
        {
            result = _currentStock[0];//agarro el 0 de la lista
            _currentStock.RemoveAt(0);//le aviso a la lista que lo movi 
        } else
        {
            result = _factoryMethod(); //_factoryMethod en este caso es el prejectileCreator del factory.  Eso devuelve 1. Sin embargo, no estoy agregando ese 1 a la lista de pool
        }
        _turnOnOffCallback(result, true);
        return result;
    }

    public void ReturnObject(obj T)
    {
        _turnOnOffCallback(T, false);
        _currentStock.Add(T);
    }
}
