using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class pauseMenu : MonoBehaviour
{
    //This script handles the pause menu logic
    public GameObject pauseM;
    bool isPaused = false;
    AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        pauseM.SetActive(false);
        audioManager = this.gameObject.GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();


    }

    public void ProcessInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {


            if (isPaused == false)
            {

                Time.timeScale = 0;
                pauseM.SetActive(true);

                isPaused = true;


            }
            else if (isPaused == true)
            {

                Time.timeScale = 1;
                pauseM.SetActive(false);
                isPaused = false;


            }

        }
    }

    public void _Continue()
    {
        Time.timeScale = 1f;
        pauseM.SetActive(false);

    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void ViewControls()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1f;
    }
    public void Quit()
    {
        Application.Quit(0);
    }

}
