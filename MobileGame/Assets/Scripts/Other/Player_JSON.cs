using UnityEngine;
using System.IO;
public class Player_JSON : MonoBehaviour
{
	[SerializeField] private SaveData _data;
	private string _path;
	private void Start()
	{
		_path = Application.persistentDataPath + "/data.json";
	}

	public void Save()
	{
		Debug.Log($"<color=yellow>Saved Data</color>");
		string jsonData = JsonUtility.ToJson(_data, true );
		File.WriteAllText(_path, jsonData);
	}
	[ContextMenu("LoadData")]
	public void LoadData()
	{
		Debug.Log($"<color=yellow>Loaded Data</color>");
		string jsonLoadData = File.ReadAllText(_path );
		//_data =JsonUtility.FromJson<SaveData>(jsonLoadData); se usa para clases que heredan de Monobehaviour
		JsonUtility.FromJsonOverwrite(jsonLoadData, _data);
	}
}