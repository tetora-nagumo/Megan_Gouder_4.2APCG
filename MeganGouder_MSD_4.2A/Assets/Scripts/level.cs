using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float DelaySeconds = 2f;

    
    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        PlayerPrefs.SetInt("Score", FindAnyObjectByType<ScoreText>().GetPoints());
        PlayerPrefs.SetInt("Health", FindAnyObjectByType<Player>().GetPlayerHealth());
        PlayerPrefs.Save();
        SceneManager.LoadScene("KittyDefender");
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad());
    }

    public  void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(DelaySeconds);
        SceneManager.LoadScene("GameOver");
    }

    public void StartNewGame()
{
    PlayerPrefs.SetInt("Score", 0);
    PlayerPrefs.Save();
    SceneManager.LoadScene("KittyDefender");
}

    public void LoadLevel2()
    {
        ScoreText scoreText = FindAnyObjectByType<ScoreText>();
        Player health = FindAnyObjectByType<Player>();
        if (scoreText != null)
        {
            PlayerPrefs.SetInt("Score", scoreText.GetPoints());
            PlayerPrefs.SetInt("Health", health.GetPlayerHealth());
            PlayerPrefs.Save();
        }

    SceneManager.LoadScene("KittyDefenderLvl2");
    }

    public void LoadWinScreen()
    {
        SceneManager.LoadScene("WinScreen");
    }
}

