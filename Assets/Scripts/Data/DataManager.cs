using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public ScoreDataList sdl;


    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        LoadData();
    }

    private void LoadData()
    {
        string readScoreString = PlayerPrefs.GetString("scoreList");
        if (readScoreString != null && readScoreString != "")
        {
            sdl = JsonUtility.FromJson<ScoreDataList>(readScoreString);
        }
    }
}
