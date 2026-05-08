using TMPro;
using UnityEngine;

public class ScoreRow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerName;
    [SerializeField] private TextMeshProUGUI scoreValue;

    void Start()
    {
       /*  playerName.text = "";
        scoreValue.text = ""; */
    }

    public void SetData(ScoreData data)
    {
        playerName.text = data.name;
        scoreValue.text = data.score.ToString();
    }
}
