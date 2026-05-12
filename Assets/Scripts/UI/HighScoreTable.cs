using System.Collections.Generic;
using UnityEngine;

public class HighScoreTable : MonoBehaviour
{
    [SerializeField] private Transform content;
    [SerializeField] private GameObject rowPrefab;
    
    void Start()
    {
        RefreshTableContent();
    }

    public void RefreshTableContent()
    {
        // Borramos todo el contenido de la tabla
        foreach (Transform t in content.GetComponentInChildren<Transform>())
        {
            Destroy(t.gameObject);
        }

        // Rellenamos la tabla
        foreach (ScoreData sd in DataManager.instance.sdl.list)
        {
            GameObject row = Instantiate(rowPrefab);
            row.GetComponent<ScoreRow>().SetData(sd);
            row.transform.parent = content;
        }
    }
}
