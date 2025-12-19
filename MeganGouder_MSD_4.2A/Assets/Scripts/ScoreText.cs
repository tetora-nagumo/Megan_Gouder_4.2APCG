using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    TMP_Text scoreText;
    int points = 0;

    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        points = PlayerPrefs.GetInt("Score", 0);
        scoreText.text = points.ToString();
    }

    public void AddPointsPickUp()
    {
        points += 10;
        scoreText.text = points.ToString();
    }

    public int GetPoints()
    {
    return points;
    }
}

