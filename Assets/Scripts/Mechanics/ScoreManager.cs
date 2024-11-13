using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements.Experimental;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText = null;
    public TextMeshProUGUI keyText = null;
    public TextMeshProUGUI MajorKeyText = null;
    public int targetScore = 4;
    public int item = 0;
    public int key = 0;
    public int majorKey = 0;
    public int completed =0;
    public GameObject EvexitOP;
    public GameObject task1;
    public GameObject task2;
    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreText();
        EvexitOP.SetActive(true);
        task1.SetActive(true);
        task2.SetActive(false);
    }

    public void addScore(int value)
    {
        item += value;
        UpdateScoreText();
    }
    public void addKey(int value)
    {
        key += value;
        UpdateScoreText();
    }
    public void addMajorKey(int value)
    {
        majorKey += value;
        UpdateScoreText();
    }
    // Update is called once per frame
    void UpdateScoreText()/////////////////////////////////
    {
        scoreText.text = item.ToString();
        keyText.text = key.ToString();
        MajorKeyText.text = majorKey.ToString();

        if(item >= targetScore && majorKey !=0)                     ////
        {
            //SceneManager.LoadScene("YAY");
            completed = completed +1;
            Debug.LogWarning("DONE");
            EvexitOP.SetActive(false);
            task1.SetActive(false);
            task2.SetActive(true);
        }
    }
}
