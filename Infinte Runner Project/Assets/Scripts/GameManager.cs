using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private bool gamePaused = false;

    void Start ()
    {
        if (instance == null)
            instance = this;
        else if (instance != this.gameObject)
            Destroy(gameObject  );

        DontDestroyOnLoad(gameObject);	
	}
	
	void Update ()
    {
        if (Input.GetKeyUp(KeyCode.R))
            SceneManager.LoadScene("Game");

        if (Input.GetKeyUp(KeyCode.M))
            SceneManager.LoadScene("Main");

        if (GameObject.FindGameObjectWithTag("Player").transform.position.y < -6f)
            SceneManager.LoadScene("Game");

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(gamePaused == true)
            {
                gamePaused = !gamePaused;
                Time.timeScale = 1f;
            }
            else
            {
                gamePaused = !gamePaused;
                Time.timeScale = 0f;
            }
        }
	}
}
