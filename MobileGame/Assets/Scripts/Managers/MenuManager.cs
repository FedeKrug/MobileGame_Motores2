using TMPro;

using UnityEngine;

public class MenuManager : MonoBehaviour
{
	public static MenuManager instance;

	[SerializeField] private TextMeshProUGUI[] _coinsCantText;
	[SerializeField] private TextMeshProUGUI _lvlText;
	SaveData _saveData;
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
		_saveData = DataManager.instance.data;
	}


	private void Start()
	{
		DataManager.instance.LoadData();
		UpdateMenuUI();
	}

	public void UpdateMenuUI()
	{
		for (int i = 0; i < _coinsCantText.Length; i++)
		{
			_coinsCantText[i].text = _saveData.coins.ToString();
		}
		//_lvlText.text = _saveData.lvl.ToString();

	}


}