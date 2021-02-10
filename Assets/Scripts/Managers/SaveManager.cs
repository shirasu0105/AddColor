using System;
using UnityEngine;
public class SaveManager : MonoBehaviour
{
    public SaveDate SaveDate { get; private set; }

    public void LoadDataFromLocal()
    {
        string json = PlayerPrefs.GetString("SaveDate", null);
        SaveDate = String.IsNullOrEmpty(json) ? new SaveDate() : JsonUtility.FromJson<SaveDate>(json);
    }

    public void SaveDataToLocal()
    {
        var json = JsonUtility.ToJson(SaveDate);
        PlayerPrefs.SetString("SaveDate", json);
    }
}

[Serializable]
public class SaveDate
{
    public int bestScore = 0;
}
