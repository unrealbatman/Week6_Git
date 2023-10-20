using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioClip[] clips;
    private void Awake()
    {
        GetComponent<AudioSource>().clip = (clips[Random.Range(0, clips.Length)]);
        GetComponent<AudioSource>().loop = true;
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
