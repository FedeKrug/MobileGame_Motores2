using TMPro;

using UnityEngine;

public class MenuManager : MonoBehaviour
{
	public static MenuManager instance;

	[SerializeField] private TextMeshProUGUI _coinsCantText;

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

	SaveData _saveData;

	private void Start()
	{
		Player_JSON.instance.LoadData();
		_saveData = UIManager.instance.SaveData;

	}

	private void UpdateMenuUI()
	{
		_coinsCantText.text = _saveData.coins.ToString();

	}


}