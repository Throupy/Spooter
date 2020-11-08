using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class DatabaseHandlerScript : MonoBehaviour
{

    public void SavePlayerData()
	{
		BinaryFormatter formatter = new BinaryFormatter();
		string path = Application.persistentDataPath + "/player.data";
		FileStream stream = new FileStream(path, FileMode.Create);
		PlayerData player = new PlayerData();
		player.name = "Owen";
		player.lastScore = 5;
		formatter.Serialize(stream, player);
		Debug.Log("Saved data to " + path);
	}

	public void LoadPlayerData()
	{
		GetPlayerData();
	}

	public PlayerData GetPlayerData()
	{
		string path = Application.persistentDataPath + "/player.data";
		if (File.Exists(path))
		{
			BinaryFormatter formatter = new BinaryFormatter();
			FileStream stream = new FileStream(path, FileMode.Open);
			PlayerData player = formatter.Deserialize(stream) as PlayerData;
			stream.Close();
			return player;
		} else
		{
			Debug.LogError("Save fiel not found");
			return null;
		}
	}
}
