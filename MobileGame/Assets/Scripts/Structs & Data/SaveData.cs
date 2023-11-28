using UnityEngine;
using System;
using System.IO;


[Serializable]
public class SaveData
{
	public float life = 100;
	public float mana;
	public string[] abilities;

	public int coins;


	//TODO: Agregar todo lo que necesita ser guardado
}
