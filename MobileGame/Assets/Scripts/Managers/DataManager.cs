
using UnityEngine;
using System.IO;
using System;

public class DataManager : MonoBehaviour
{
	public static DataManager instance;
	public SaveData data;
	private string _path;

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

	public void Save()
	{
		
		Debug.Log($"<color=yellow>Saved Data</color>");
		string jsonData = JsonUtility.ToJson(data, true);
		File.WriteAllText(_path, jsonData);
	}

	public void LoadData()
	{
		if (!File.Exists(_path))
		{
			Debug.Log($"<color=yellow>There's no Data to Load</color>");
			Save();
			//Por si quiero guardar en caso de que no haya ninguna partida guardada y quiero cargar el juego
			return;
		}
		
		Debug.Log($"<color=yellow>Loaded Data</color>");
		string jsonLoadData = File.ReadAllText(_path);
		//_data =JsonUtility.FromJson<SaveData>(jsonLoadData); se usa para clases que heredan de Monobehaviour
		JsonUtility.FromJsonOverwrite(jsonLoadData, data);
		UIManager.instance.LoadDataUI();

	}

	[ContextMenu("Clear Data ")]
	public void ClearData()
	{
		SaveData emptyData = new();
		Debug.Log($"<color=yellow>Clear Data</color>");
		data = emptyData;
		string jsonData = JsonUtility.ToJson(data, true);
		File.WriteAllText(_path, jsonData);

	}
}
