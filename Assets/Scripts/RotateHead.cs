using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHead : MonoBehaviour
{
    public GameObject player;
    //this script rotates the boss's head to aim at the player while shooting lasers.


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(player.transform.position);


    }
}
