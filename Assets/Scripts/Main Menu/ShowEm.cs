using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowEm : MonoBehaviour
{
    public Animator quit;
    public Animator playGame;
    public Animator htp;

    public GameObject quitUI;
    public GameObject playGUI;
    public GameObject htpUI;
    // Start is called before the first frame update
    void Start()
    {
        //quitUI.SetActive(true);
        //playGUI.SetActive(true);
        //htpUI.SetActive(true);
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "How To")
        {
            Debug.Log("inside");
            htp.SetBool("inside?", true);
        }

        if(other.gameObject.name == "Exit")
        {
            Debug.Log("inside");
            quit.SetBool("inside?", true);
        }

        if(other.gameObject.name == "Play")
        {
            Debug.Log("inside");
            playGame.SetBool("inside?", true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.name == "How To")
        {
            htp.SetBool("inside?", false);
        }

        if(other.gameObject.name == "Exit")
        {
            quit.SetBool("inside?", false);
        }

        if(other.gameObject.name == "Play")
        {
            playGame.SetBool("inside?", false);
        }
    }
        


}
