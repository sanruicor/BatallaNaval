using System;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public ScoreDataList sdl;


    void Awake()
    {
        instance = this;
        LoadData();
    }

    private void LoadData()
    {
        string readScoreString = PlayerPrefs.GetString("scoreList");
        if (readScoreString != null && readScoreString != "")
        {
            sdl = JsonUtility.FromJson<ScoreDataList>(readScoreString);
            sdl.list.Sort();
            sdl.list.Reverse();
        }
    }

    public void SaveData(ScoreData scoreData)
    {
        sdl.list.Add(scoreData);
        sdl.list.Sort();
        sdl.list.Reverse();
        string scoreString = JsonUtility.ToJson(sdl);
        PlayerPrefs.SetString("scoreList", scoreString);
        PlayerPrefs.Save();

        Debug.Log("[DataManager] Save data scoreString: " + scoreString);
    }
}
