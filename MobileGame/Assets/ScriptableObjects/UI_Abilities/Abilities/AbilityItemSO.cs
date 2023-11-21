using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Abilities_Gameplay", fileName = "new Ability")]
public class AbilityItemSO : ScriptableObject
{
	public string abilityName;
	public string abilityDescription;
	public Sprite abilityIcon;
}
