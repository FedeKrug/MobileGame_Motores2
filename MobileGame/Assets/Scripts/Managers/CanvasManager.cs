using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
	public static CanvasManager instance;
	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}

	#region CanvasManager
	/*..............................................................CANVAS MANAGER..........................................*/
	[Header("Screens")]
	[SerializeField] private Canvas[] _menuCanvas;

	[Header("Sliders")]
	//[SerializeField, Range(0.0001f, 1f)] private float _initMusicVol = 0.0001f;
	[SerializeField] private Slider[] _sliders;
	//[SerializeField] private AsyncSceneLoader _asynSceneLoader;


	private void Start()
	{
		//Debug.Log($"<color=#F34D0E>{_menuCanvas[0]} es el canvas numero 0.</color>");
		for (int i = 0; i < _menuCanvas.Length; i++)
		{
			_menuCanvas[i].enabled = i == 0;
		}
	}


	public void EnableMenu(int menuToShow)
	{
		//if (_asynSceneLoader != null)
		//{
		//	if (_asynSceneLoader.IsAsyncLoading) return;

		//}
		for (int i = 0; i < _menuCanvas.Length; i++)
		{
			if (i == menuToShow)
			{
				_menuCanvas[i].enabled = true;
			}
			else if (i != menuToShow && _menuCanvas[i].enabled)
			{
				_menuCanvas[i].enabled = false;
			}
		}
	}

	public void TurnOffMenus()
	{
		for (int i = 0; i < _menuCanvas.Length; i++)
		{
			_menuCanvas[i].enabled = false;
		}
	}
	#endregion


}
