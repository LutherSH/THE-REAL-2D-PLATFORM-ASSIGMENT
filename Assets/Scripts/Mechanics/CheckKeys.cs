using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckKeys : MonoBehaviour
{
    // Start is called before the first frame update
    public ScoreManager scoreManager;
    private int loss = -1;
    public GameObject closeThis;
    public GameObject showThis;
    private bool opened = false;
    public int keyCunt;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckKey();
    }

    void CheckKey()
    {
        keyCunt = scoreManager.key;
        //Debug.Log("Keys = " + keyCunt);   
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            CheckKey();
            if(keyCunt == 0)
            {
                Debug.Log("No Keys");
            }

            if(keyCunt >=1 && opened == false)
            {
                Opensesami();
                scoreManager.addKey(loss);
                opened = true;
            }
            
        }
    }
    void Opensesami()
    {
        closeThis.SetActive(false);
        showThis.SetActive(true);
    }
}
