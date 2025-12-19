using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level : MonoBehaviour
{
    [SerializeField] float DelaySeconds = 2f;

    
    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        PlayerPrefs.SetInt("Score", FindAnyObjectByType<ScoreText>().GetPoints());
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
    
}
