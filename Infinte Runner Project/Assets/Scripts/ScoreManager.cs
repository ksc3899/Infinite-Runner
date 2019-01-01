using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private TextMeshProUGUI scoreText;   

    private void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void Update ()
    {
        scoreText.text = "Score: " + playerMovement.score.ToString();
	}
}
