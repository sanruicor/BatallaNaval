using System;
using System.Collections.Generic;

[Serializable]
public struct ScoreData
{
    public string name;
    public int score;

    public ScoreData (string name, int score)
    {
        this.name = name;
        this.score = score;
    }
}

[Serializable]
public class ScoreDataList
{
    public static List<ScoreData> list = new List<ScoreData>();
}
