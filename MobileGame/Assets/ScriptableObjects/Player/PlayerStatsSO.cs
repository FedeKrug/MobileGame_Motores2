using UnityEngine;


[CreateAssetMenu(menuName = "Scriptable Objects/Player Stats", fileName = "new PlayerStats")]

//Uso un scriptableObject en lugar de un struct porque quiero que esta info sea persistente.
public class PlayerStatsSO : ScriptableObject
{
	[Header("Health:")]
	public int healthPointsHP = 100;
	//HP
	public int defPoints = 1;
	[Space(10)]
	[Header("Atk:")]
	public int atkPoints = 2;
	public float atkCooldown = 1.5f;
	//Medido en %.
	public int criticalHitRate = 5;
	//Si se da la condicion para ataque critico, depende del criticalHitRate

	[Space(10)]
	[Header("SpecialAtk:")]
	public int specialDamage = 20;
	//Una especie de ataque maximo (como un estado en que su ataque es especial)

	public float spcAtkCooldown = 8;
	//Lo que va a durar el specialAttack en su totalidad

	[Space(10)]
	[Header("Speed:")]
	public float movementSpeed = 500;


	[Space(10)]
	[Header("LevelExp:")]
	public int currentLevel = 1;
	public int expPoints = 0;
	//TODO: Buscar logica de subida de niveles


	//[Lvl/exp]
	//Character level -> int : 8
	//Experience points(XP) -> float/float: 180/1500

	//[HP/MP]
	//Health points(HP) -> int/int : 50/100 
	//Mana or energy points(MP/EP) -> int/int : 25/380

	//[Damage]
	//Attack power(ATK)
	//Defense or armor rating(DEF)
	//Speed or agility
	//Critical hit rate

	//Elemental resistances


}
