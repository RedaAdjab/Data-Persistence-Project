using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string playerName;
    public string highScoreName;
    public int highScore;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this; //change this
            playerName = "John";
            highScoreName = playerName;
            highScore = 0;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [System.Serializable]
    class SaveData
    {
        public int highScore;
        public string highScoreName;
    }

    public void SaveHighScore()
    {
        SaveData data = new()
        {
            highScore = highScore,
            highScoreName = highScoreName
        };
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/saveData.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/saveData.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            highScore = data.highScore;
            highScoreName = data.highScoreName;
        }
    }
}
