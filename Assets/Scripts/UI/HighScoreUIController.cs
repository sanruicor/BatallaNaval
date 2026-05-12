using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighScoreUIController : MonoBehaviour
{
    public static HighScoreUIController instance;
    [SerializeField] private TextMeshProUGUI scoreValue;
    [SerializeField] private TMP_InputField playerNameInput;
    [SerializeField] private HighScoreTable hst;
    [SerializeField] private GameObject newScoreSection;
    [SerializeField] private GameObject newGameSection;
    private int score;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        newScoreSection.SetActive(true);
        newGameSection.SetActive(false);
    }

    void Update()
    {
        
    }

    public void SaveScoreButtonOnClick()
    {
        Debug.Log("[HighScoreUIController] " + playerNameInput.text + ": " + scoreValue.text);
        DataManager.instance.SaveData(new ScoreData(playerNameInput.text, score));
        hst.RefreshTableContent();

        newScoreSection.SetActive(false);
        newGameSection.SetActive(true);
    }

    public void NewGameButtonOnClick()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void SetScore(int score)
    {
        scoreValue.text = score.ToString();
        this.score = score;
    }
}
