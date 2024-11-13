using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MajorKeyLogger : MonoBehaviour
{
    public ScoreManager scoreManager;   public int LV;
    public int Majorkey;
    public int done;
    public Animator DoorR;
    public Animator DoorL;
    public Animator playerStopAN;
    public SceneScript sceneScript;
    public float Delay = 3f;
    public GameObject EvexitOP;
    public PlayerControl playerControl;
    // Start is called before the first frame update
    void Start()
    {
        EvexitOP.SetActive(true);
        playerStopAN.SetBool("End?",false);
        if(LV <= 0 )
        {
            Debug.LogError("LV NOT ASSIGN DUMBASS");
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckMajorKey();
    }

    void CheckMajorKey()
    {
        Majorkey = scoreManager.majorKey;
        done = scoreManager.completed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            CheckMajorKey();
            if(Majorkey == 1 && done !=0)
            {
                //sceneScript.Test1();
                Debug.LogWarning("NEXT");
                DoorR.SetBool("isDoneR?", true);
                DoorL.SetBool("isDoneL?", true);
                StartCoroutine(waitTime());
                playerControl.enabled = false;
                playerStopAN.SetBool("isRLX?" , true);
                playerStopAN.SetBool("End?",true);
                EvexitOP.SetActive(false);
            }
        }
    }

    private IEnumerator waitTime()
    {
        yield return new WaitForSeconds(Delay);
        //sceneScript.Test1();
        if(LV == 1)
        {
            sceneScript.Level2();
        }
        if(LV == 2)
        {
            sceneScript.Level3();
        }
        if(LV == 3)
        {
            sceneScript.Ending();
        }

    }
}
