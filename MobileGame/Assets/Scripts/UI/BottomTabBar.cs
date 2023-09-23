using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomTabBar : MonoBehaviour
{
	[SerializeField] private Canvas[] _screens;
	[SerializeField] private Image[] _screenButtons;
	[SerializeField] private Canvas _firstScreen;
	public void ChangeScreen(int screenIndex)
	{
		for (int i = 0; i< _screens.Length; i++)
		{			
			_screens[i].enabled = i == screenIndex;
			_screenButtons[i].color = i == screenIndex ? Color.green: Color.white;
		}
	}
}
