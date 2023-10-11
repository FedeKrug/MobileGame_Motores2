using UnityEngine;
using System.IO;
using System;
public class Player_JSON : MonoBehaviour
{
	[SerializeField] private SaveData _data;
	private string _path;
	private void Start()
	{
		string _newPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).Replace("\\", "/") + $"/{Application.productName}";
		_path = _newPath + "/data.json";
		Directory.CreateDirectory(_newPath);

		
	}

	public void Save()
	{
		_data = UIManager.instance.SaveData;
		Debug.Log($"<color=yellow>Saved Data</color>");
		string jsonData = JsonUtility.ToJson(_data, true);
		File.WriteAllText(_path, jsonData);
	}
	[ContextMenu("LoadData")]
	public void LoadData()
	{
		if (!File.Exists(_path))
		{
			Debug.Log($"<color=yellow>There's no Data to Load</color>");
			//Save();
			//Por si quiero guardar en caso de que no haya ninguna partida guardada y quiero cargar el juego
			return;
		}
		_data = UIManager.instance.SaveData;
		Debug.Log($"<color=yellow>Loaded Data</color>");
		string jsonLoadData = File.ReadAllText(_path);
		//_data =JsonUtility.FromJson<SaveData>(jsonLoadData); se usa para clases que heredan de Monobehaviour
		JsonUtility.FromJsonOverwrite(jsonLoadData, _data);
		UIManager.instance.UpdateScoreText();
		GameManager.instance.UpdateCoinsAmountSO();
	}
}