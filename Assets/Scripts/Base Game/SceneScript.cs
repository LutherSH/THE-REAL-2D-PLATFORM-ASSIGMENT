using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
    public GameObject gameOver;
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Gameplay()
    {
        SceneManager.LoadScene("LV1");
    }
    public void Level2()
    {
        SceneManager.LoadScene("LV2");
    }

    public void Level3()
    {
        SceneManager.LoadScene("LV3");
    }
    public void Ending()
    {
        SceneManager.LoadScene("YAY");
    }
    public void BackMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Start()
    {
        Time.timeScale =1f;
        gameOver.SetActive(false);
    }

    public void SkillIssue()
    {
        //Application.Quit();
        Debug.Log("QUIT");
    }
}
