using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static EnemyLevelManager Instance {get; private set;}
     void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    private int totaljerks;
    void Start()
    {
        totaljerks = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    public void JerkDies()
    {
        totaljerks--;
        if(totaljerks <=0)
        {
            Debug.Log("NICE");
        }
    }
    // Update is called once per frame
}
