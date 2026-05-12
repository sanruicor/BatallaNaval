using System;
using System.Collections.Generic;

[Serializable]
public struct ScoreData : IComparable<ScoreData>
{
    public string name;
    public int score;

    public ScoreData (string name, int score)
    {
        this.name = name;
        this.score = score;
    }

    public int CompareTo(ScoreData other)
    {
        if (this.score < other.score)
        {
            return -1;
        } 
        else if (this.score > other.score)
        {
            return 1;
        }
        return 0;
    }
}

[Serializable]
public class ScoreDataList
{
    public List<ScoreData> list = new List<ScoreData>();
}
