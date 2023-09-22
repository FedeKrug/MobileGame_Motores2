using System.Collections;
using System.Collections.Generic;


using UnityEngine;


[CreateAssetMenu(menuName = "Scriptable Objects/Player Stats", fileName = "new PlayerStats")]

//Uso un scriptableObject en lugar de un struct porque quiero que esta info sea persistente.
public class PlayerStatsSO : ScriptableObject
{
	[Header("Health:")]
	public int healthPointsHP = 100;
	//health o healthPoints (HP)?
	public int defPoints = 1;
	[Space(10)]
	[Header("Atk:")]
	public int atkPoints = 2;
	public float atkCooldown = 1.5f;
	//Medido en %.
	public int criticalHitRate = 5;
	[Space(10)]
	[Header("SpecialAtk:")]
	public int specialDamage = 20;
	public float spcAtkCooldown = 8;
	[Space(10)]
	[Header("Speed:")]
	public float movementSpeed = 500;
	[Space(10)]
	[Header("LevelExp:")]
	public int currentLevel = 1;
	public int expPoints = 0;

	


	//Character level
	//Experience points(XP)

	//Health points(HP)
	//Mana or energy points(MP/EP)
	//Attack power(ATK)
	//Defense or armor rating(DEF)
	//Speed or agility
	//Critical hit rate
	//Elemental resistances


}
