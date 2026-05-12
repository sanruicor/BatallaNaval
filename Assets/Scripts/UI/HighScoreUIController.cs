using TMPro;
using UnityEngine;

public class HighScoreUIController : MonoBehaviour
{
    public static HighScoreUIController instance;
    [SerializeField] private TextMeshProUGUI scoreValue;
    [SerializeField] private TMP_InputField playerNameInput;
    [SerializeField] private HighScoreTable hst;
    private int score;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SaveScoreButtonOnClick()
    {
        Debug.Log("[HighScoreUIController] " + playerNameInput.text + ": " + scoreValue.text);
        DataManager.instance.SaveData(new ScoreData(playerNameInput.text, score));
        hst.RefreshTableContent();
    }

    public void SetScore(int score)
    {
        scoreValue.text = score.ToString();
        this.score = score;
    }
}
