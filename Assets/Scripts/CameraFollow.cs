using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //This script ensures that the camera follows the player as they move in the environment

    private GameObject player;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        this.transform.position = new Vector3(this.transform.position.x, player.transform.position.y, player.transform.position.z);

    }
}
