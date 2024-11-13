using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
////////////////////////////////////////////////////////////////////////
    public int scoreVal = 1;
    public bool cooldown;
    public float howLong = 0.2f;
    public ScoreManager scoreManager;
    public bool isItem = false;
    public bool isKey = false;
    public bool isMajorKey = false;

////////////////////////////////////////////////////////////////////////
    // Start is called before the first frame update
     void OnTriggerEnter2D(Collider2D collision)
    {
        ////////////////////////////////////////////////////////////////////////
        /// ITEM COUNTER
        if(cooldown == false && collision.CompareTag("Player"))
        {
            if(isItem == true)
            {
                scoreManager.addScore(scoreVal);
                Destroy(gameObject);
                cooldown =true;
                StartCoroutine(HangOn());
            }

            if(isKey == true)
            {
                scoreManager.addKey(scoreVal);
                Destroy(gameObject);
                cooldown =true;
                StartCoroutine(HangOn());
            }

            if(isMajorKey == true)
            {
                scoreManager.addMajorKey(scoreVal);
                Destroy(gameObject);
                cooldown =true;
                StartCoroutine(HangOn());
            }
        }
        ////////////////////////////////////////////////////////////////////////
    }
    IEnumerator HangOn()
    {
        yield return new WaitForSeconds(howLong);
        cooldown = false;
    }
}
