//using UnityEngine;
//using System.IO;
//using System;
//public class Player_JSON : MonoBehaviour
//{
//	private SaveData _data;
//	private string _path;

//	public static Player_JSON instance;

//	private void Awake()
//	{
//		if (instance == null)
//		{
//			instance = this;
//		}
//		else
//		{
//			Destroy(gameObject);
//		}
//	}

//	private void Start()
//	{
//		string _newPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).Replace("\\", "/") + $"/{Application.productName}";
//		_path = _newPath + "/data.json";
//		Directory.CreateDirectory(_newPath);
//	}

//	public void Save()
//	{
//		_data = DataManager.instance.data;
//		Debug.Log($"<color=yellow>Saved Data</color>");
//		string jsonData = JsonUtility.ToJson(_data, true);
//		File.WriteAllText(_path, jsonData);
//	}

//	public void LoadData()
//	{
//		if (!File.Exists(_path))
//		{
//			Debug.Log($"<color=yellow>There's no Data to Load</color>");
//			Save();
//			//Por si quiero guardar en caso de que no haya ninguna partida guardada y quiero cargar el juego
//			return;
//		}
//		_data = DataManager.instance.data;
//		Debug.Log($"<color=yellow>Loaded Data</color>");
//		string jsonLoadData = File.ReadAllText(_path);
//		//_data =JsonUtility.FromJson<SaveData>(jsonLoadData); se usa para clases que heredan de Monobehaviour
//		JsonUtility.FromJsonOverwrite(jsonLoadData, _data);
//		UIManager.instance.LoadDataUI();

//	}

//	[ContextMenu("Clear Data ")]
//	public void ClearData()
//	{
//		SaveData emptyData = new();
//		Debug.Log($"<color=yellow>Clear Data</color>");
//		_data = emptyData;
//		string jsonData = JsonUtility.ToJson(_data, true);
//		File.WriteAllText(_path, jsonData);

//	}
//}