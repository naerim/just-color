using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameResult : MonoBehaviour
{
    private int highScore;
    public Text resultScore;
    public Text bestScore;
    public GameObject resultUI;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
        }
        else
        {
            highScore = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(TheEnd.over)
        {
            resultUI.SetActive(true);
            int result = Mathf.FloorToInt(Timer.time);

            if (highScore < result)
            {
                PlayerPrefs.SetInt("HighScore", result);
            }

            resultScore.text = "Result Score: " + result;
            bestScore.text = "Best Score: " + highScore;
        }
    }

    public void OnRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoStartScene()
    {

    }
}
