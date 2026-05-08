using TMPro;
using UnityEngine;

public class HighScoreUIController : MonoBehaviour
{
    public static HighScoreUIController instance;
    [SerializeField] private TextMeshProUGUI scoreValue;
    [SerializeField] private TMP_InputField playerNameInput;

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
    }

    public void SetScore(int score)
    {
        scoreValue.text = score.ToString();
    }
}
