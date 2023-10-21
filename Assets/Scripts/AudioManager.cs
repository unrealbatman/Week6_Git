using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{


    //This script manages the background music for the main menu and the ambient sounds for each level
    public AudioClip menu;
    public AudioClip level1;
    public AudioClip level2;
    public AudioClip level3;
    public AudioClip level4;


     AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {

           audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        playAudio();

    }

    public void playAudio()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        switch (currentSceneIndex)
        {
            case 0:
            case 1:
            case 2:
                GameObject.FindGameObjectWithTag("Music")?.GetComponent<MenuMusic>().PlayMusic();

                break;
            case 3:
                audioSource.clip = level1;
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();

                }
                GameObject.FindGameObjectWithTag("Music")?.GetComponent<MenuMusic>().StopMusic();

                
                break;
            case 4:
                audioSource.clip = level2;
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
                GameObject.FindGameObjectWithTag("Music")?.GetComponent<MenuMusic>().StopMusic();

                break;
            case 5:
                audioSource.clip = level3;
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
                GameObject.FindGameObjectWithTag("Music")?.GetComponent<MenuMusic>().StopMusic();

                break;
            case 6:
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
                audioSource.clip = level4;
                GameObject.FindGameObjectWithTag("Music")?.GetComponent<MenuMusic>().StopMusic();

                break;

        }
    }

   public void stopAudio()
    {
        audioSource.Stop();
    }

}
