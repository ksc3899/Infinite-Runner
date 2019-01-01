using UnityEngine;
using TMPro;

public class HighScoreManager : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private TextMeshProUGUI highScoreText; 
    
    private void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        highScoreText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (playerMovement.score > GetHighScore())
            PlayerPrefs.SetInt("HighScore", playerMovement.score);

        highScoreText.text = "High Score: " + GetHighScore(); 
    }

    private int GetHighScore()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        return highScore;
    }
}
