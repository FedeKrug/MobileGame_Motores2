using UnityEngine;

public class TabBar : MonoBehaviour
{
	[SerializeField] private ShowAbilitySO[] _ablities;

	public void SelectedEffect()
	{

	}
	public void DeselectedEffect(int index)
	{
		for (int i=0; i<_ablities.Length; i++)
		{
			//_ablities[i].enabled = i == index;
			if (i != index)
			{
				_ablities[i].Deselect();
			}
			else
			{
				_ablities[i].Select();
			}

		}
	}
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
