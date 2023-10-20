using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FloorDetection : MonoBehaviour
{
    public bool gameOverTrigger;
    public Material lava;
    public Renderer _Rdr;
    

    void Start(){
        _Rdr = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (gameOverTrigger)
            {
                Debug.Log("Game Over");
                SceneManager.LoadScene("LoseScreen");

            }
        }
    }
    
}
