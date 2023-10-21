using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{

    //this script manages the main menu UI
    public bool isStart;
    public bool isStory;
    public bool isQuit;
    public bool isBack;
    public bool isViewControls;



    void OnMouseUp()
    {
        if (isStart)
        {
            SceneManager.LoadScene(3);

            this.gameObject.GetComponent<Renderer>().material.color = Color.cyan;
        }

        if (isStory)
        {
            SceneManager.LoadScene(1);
            this.gameObject.GetComponent<Renderer>().material.color = Color.cyan;
        }
        if (isBack)
        {
            SceneManager.LoadScene(0);
            this.gameObject.GetComponent<Renderer>().material.color = Color.cyan;
        }
        if (isQuit)
        {
            Application.Quit(0);

        }
        if (isViewControls)
        {
            SceneManager.LoadScene(2);
        }
    }
}
