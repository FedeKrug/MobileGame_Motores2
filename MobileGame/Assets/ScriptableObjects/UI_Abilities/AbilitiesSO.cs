using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


[CreateAssetMenu(fileName ="new Ability", menuName ="Scriptable Objects/Ability")]
public class AbilitiesSO : ScriptableObject
{
	public Image abilityIcon;
	public int abilityMastery;
	public string abilityName;

}



//[Lvl/exp]
//Arriba
//Character level -> int : 8
//Experience points(XP) -> float/float: 180/1500

//[HP/MP]
//No van en el menu?:
//Health points(HP) -> int/int : 50/100 
//Mana or energy points(MP/EP) -> int/int : 25/380

//[Damage]
//Van en el menu:
//Attack power(ATK)
//Defense or armor rating(DEF)
//Speed or agility
//Critical hit rate

//Elemental resistances?
