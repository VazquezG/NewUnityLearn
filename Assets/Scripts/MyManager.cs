using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class MyManager : MonoBehaviour
{
    public static MyManager Instance;
    public string playerName;
    public string holdName;
    public int maxScore;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadInfo();
    }


    [System.Serializable]
    class SavedData
    {
        public string playerName;
        public int maxScore;
    }

    public void SaveInfo()
    {
        SavedData data = new SavedData();
        data.playerName = playerName;
        data.maxScore = maxScore;
        

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadInfo()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SavedData data = JsonUtility.FromJson<SavedData>(json);

            playerName = data.playerName;
            maxScore = data.maxScore;
        }
    }

}
