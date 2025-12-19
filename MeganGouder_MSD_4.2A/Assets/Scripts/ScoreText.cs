using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    TMP_Text scoreText;
    int points = 0;

    void Start()
    {
        scoreText = GetComponent<TMP_Text>();

        int savedScore = PlayerPrefs.GetInt("Score", 0);
        UpdateUI(savedScore);
    }

    public void AddPointsPickUp()
    {
        UpdateUI(points + 10);
        PlayerPrefs.SetInt("Score", points);
        PlayerPrefs.Save();
    }

    public void UpdateUI(int newPoints)
    {
        points = newPoints;
        scoreText.text = points.ToString();
    }

    public int GetPoints()
    {
        return points;
    }
}


