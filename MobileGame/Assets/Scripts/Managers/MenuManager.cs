using TMPro;

using UnityEngine;

public class MenuManager : MonoBehaviour
{
	public static MenuManager instance;

	[SerializeField] private TextMeshProUGUI[] _coinsCantText;
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

	//private void OnEnable()
	//{
	//	DataManager.instance.LoadData();
	//	UpdateMenuUI();
	//}

	private void Start()
	{
		DataManager.instance.LoadData();
		UpdateMenuUI();
	}

	public void UpdateMenuUI()
	{
		for (int i = 0; i < _coinsCantText.Length; i++)
		{
			_coinsCantText[i].text = DataManager.instance.data.coins.ToString();
		}
	}

	public void AddCoins(int coins)
	{
		DataManager.instance.data.coins += coins;
		UpdateMenuUI();
		DataManager.instance.Save();
	}

}