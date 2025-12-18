using UnityEngine;

public class GameSessions : MonoBehaviour
{
    int score = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        SetUpSingleton();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetUpSingleton()
    {
        DontDestroyOnLoad(gameObject);
    }

     public int GetScore()
    {
        return score;
    }
     public void AddToScore(int scoreValue)
    {
        score += scoreValue;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
   

}
