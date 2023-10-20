/*using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public GameObject blockGameObject;
    public float perlinScale = 0.1f;
    public float minHeight = 0.5f;
    public float maxHeight = 100.0f;
    public int num_blocks = 5;
    public int num_jump_blocks = 2; // Assuming you want a certain number of jumpable blocks.
    public Bounds bounds;
    private List<GameObject> blocks = new List<GameObject>();
    public bool playerOnFloor;
    public GameObject player;
    public GameObject removeBlock;
    public FloorDetection floorDetector;

    public GameObject Target;
    public int num_Targets;

    public PlatTypes typeHandle;
    public Material lava;

    void Start()
    {

        Random.InitState(System.DateTime.Now.Millisecond);

        for (int i = 0; i < num_blocks; i++)
        {
            GeneratePlatform();
        }

        // Set jumpable flag for a specified number of blocks
        for (int i = 0; i < num_jump_blocks - 1; i++)
        {
            int randomIndex = Random.Range(1, blocks.Count);
            if (!blocks[randomIndex].GetComponent<Jump>().isTarget)
            {
                blocks[randomIndex].GetComponent<Jump>().isJumpable = true;
                blocks[randomIndex].GetComponent<PlatTypes>().type = 5;
            }
            else
            {
                i--; // Retry this iteration to get a different random index
            }
        }

        for (int i = 0; i < num_Targets; i++)
        {
            int randomIndex = Random.Range(1, blocks.Count);

            if (!blocks[randomIndex].GetComponent<Jump>().isJumpable)
            {
                blocks[randomIndex].GetComponent<Jump>().isTarget = true;
                blocks[randomIndex].GetComponent<PlatTypes>().type = 1;
            }
            else
            {
                i--; // Retry this iteration to get a different random index
            }
        }


        blocks[0].GetComponent<Jump>().isJumpable = true;
        blocks[0].GetComponent<PlatTypes>().type = 5;
        blocks[0].GetComponent<PlatTypes>().initial = true;
        blocks[0].name = "InitalPad";


        for(int i = 0; i < blocks.Count; i++)
        {
            if (blocks[i].GetComponent<Jump>().isJumpable ==false && blocks[i].GetComponent<Jump>().isTarget == false)
            {
               int j = Random.Range(0, 2);
                if (j == 0)
                {
                    blocks[i].GetComponent<Jump>().isJumpable = true;
                    blocks[i].GetComponent<PlatTypes>().type = 5;

                }else if (j == 1)
                {
                    blocks[i].GetComponent<Jump>().isTarget = true;
                    blocks[i].GetComponent<PlatTypes>().type = 1;

                }
            }
        }
    }

    void GeneratePlatform()
    {
        bounds = GetComponent<Collider>().bounds;

        float offsetX = Random.Range(-bounds.extents.x, bounds.extents.x);
        float offsetZ = Random.Range(-bounds.extents.z, bounds.extents.z);

        Vector3 platformPosition;
        if (blocks.Count == 0)
        {
            platformPosition = bounds.center + new Vector3(offsetX, 0f, offsetZ);
            platformPosition.y = 3f;
            platformPosition.x = Mathf.Clamp(platformPosition.x, bounds.min.x + 1, bounds.max.x - 1);
            platformPosition.z = Mathf.Clamp(platformPosition.z, bounds.min.z + 1, bounds.max.z - 1);
        }
        else
        {
            platformPosition = bounds.center + new Vector3(offsetX, 0f, offsetZ);
            float heightValue = Mathf.PerlinNoise(platformPosition.x * perlinScale, platformPosition.z * perlinScale);
            float platformHeight = Mathf.Lerp(minHeight, maxHeight, heightValue);
            platformPosition.y = platformHeight;
        }

 
        GameObject platform = GameObject.Instantiate(blockGameObject, platformPosition, Quaternion.identity) as GameObject;
        blocks.Add(platform);
    }

    private void Update()
    {
       
        if (blocks.Contains(removeBlock))
        {
            if (removeBlock != null)
            {
                if (removeBlock.name == "InitalPad")
                {
                    floorDetector.gameOverTrigger = true;
                   // floorDetector._Rdr.material = lava;
                   floorDetector.gameObject.GetComponentInParent<MeshRenderer>().enabled = false;
                   for (int i = 0; i < GetComponentsInChildren<MeshRenderer>().Length; i++)
                    {
                        GetComponentsInChildren<MeshRenderer>()[i].enabled = false;
                    }
                }
            }
            else
            {
                blocks.Remove(removeBlock);
                GeneratePlatform();
                int rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    blocks[^1].GetComponent<PlatTypes>().type = 5;

                    blocks[^1].GetComponent<Jump>().isJumpable = true;
                    blocks[^1].GetComponent<Jump>().isTarget = false;


                }
                else if (rand == 1)
                {
                    blocks[^1].GetComponent<PlatTypes>().type = 1;

                    blocks[^1].GetComponent<Jump>().isJumpable = false;
                    blocks[^1].GetComponent<Jump>().isTarget = true;
                }

            }

           
        }

      
    }

   
}
*/