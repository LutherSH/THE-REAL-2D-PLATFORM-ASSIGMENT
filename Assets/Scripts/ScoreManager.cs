using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements.Experimental;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreText();
    }

    public void addScore(int value)
    {
        score += value;
        UpdateScoreText();
    }
    // Update is called once per frame
    void UpdateScoreText()
    {
        scoreText.text = score.ToString();
        if(score >= 40)
        {
            SceneManager.LoadScene("YAY");
        }
    }
}
