using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int scoreVal = 1;
    public bool cooldown;
    public float howLong = 0.2f;
    public ScoreManager scoreManager;
    // Start is called before the first frame update
     void OnTriggerEnter2D(Collider2D collision)
    {
        if(cooldown == false && collision.CompareTag("Player"))
        {
            scoreManager.addScore(scoreVal);
            Destroy(gameObject);
            cooldown =true;
            StartCoroutine(HangOn());
        }
    }
    IEnumerator HangOn()
    {
        yield return new WaitForSeconds(howLong);
        cooldown = false;
    }
}
