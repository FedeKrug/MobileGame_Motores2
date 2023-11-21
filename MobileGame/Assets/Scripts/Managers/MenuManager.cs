using TMPro;

using UnityEngine;

public class MenuManager : MonoBehaviour
{
	public static MenuManager instance;

	[SerializeField] private TextMeshProUGUI[] _coinsCantText;
	[SerializeField] private TextMeshProUGUI _lvlText;
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
		DataManager.instance.LoadData();
		_saveData = DataManager.instance.data;
		UpdateMenuUI();
	}

	public void UpdateMenuUI()
	{
		for (int i = 0; i < _coinsCantText.Length; i++)
		{
			_coinsCantText[i].text = _saveData.coins.ToString();
		}
		_lvlText.text = _saveData.lvl.ToString();

	}


}