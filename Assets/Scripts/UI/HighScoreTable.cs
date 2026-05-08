using System.Collections.Generic;
using UnityEngine;

public class HighScoreTable : MonoBehaviour
{
    [SerializeField] private Transform content;
    [SerializeField] private GameObject rowPrefab;

    // Para pruebas
    private List<ScoreData> data;
    
    void Start()
    {
        data = new List<ScoreData>();
        data.Add(new ScoreData("Antonio", 100));
        data.Add(new ScoreData("Belén", 120));
        data.Add(new ScoreData("Carlos", 80));

        RefreshTableContent();
    }

    void Update()
    {
        
    }

    public void RefreshTableContent()
    {
        foreach (ScoreData sd in data)
        {
            GameObject row = Instantiate(rowPrefab);
            row.GetComponent<ScoreRow>().SetData(sd);
            row.transform.parent = content;
        }
    }
}
