using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomTabBar : MonoBehaviour
{
	[SerializeField] private Canvas[] _screens;
	[SerializeField] private Canvas _firstScreen;

	private void Start()
	{
		
	}

	public void ChangeScreen(int screenIndex)
	{
		for (int i = 0; i< _screens.Length; i++)
		{
			if (i != screenIndex)
			{
				//Apagar las otras screens
				_screens[i].enabled = false;
			}
			else
			{
				_screens[i].enabled = true;
			}
		}
	}


}
