using UnityEngine;
using System.Collections.Generic;

public class RoomGenerator : MonoBehaviour
{
    public OpenAI openAI; // Assuming OpenAI component is added to the same GameObject.

    public GameObject tablePrefab;
    public GameObject chairPrefab;
    public GameObject windowPrefab;

    public int roomWidth = 10;
    public int roomLength = 10;

    void Start()
    {
        openAI = GetComponent<OpenAI>(); // Assign the OpenAI component.

        GenerateRoom();
    }

    void GenerateRoom()
    {
        string prompt = "Generate a 3D room with a table, chairs, and a window.";
        openAI.CreateCompletion(prompt, OnRoomGenerated);
    }

    void OnRoomGenerated(Response response)
    {
        if (response != null && response.choices != null && response.choices.Count > 0)
        {
            string generatedRoomDescription = response.choices[0].text.Trim();

            // Process the generated text to extract room details and instantiate objects
            ProcessGeneratedRoom(generatedRoomDescription);
        }
    }

    void ProcessGeneratedRoom(string description)
    {
        List<string> objectsToInstantiate = new List<string>();

        if (description.Contains("table"))
        {
            objectsToInstantiate.Add("table");
        }

        if (description.Contains("chairs"))
        {
            objectsToInstantiate.Add("chair");
        }

        if (description.Contains("window"))
        {
            objectsToInstantiate.Add("window");
        }

        InstantiateObjects(objectsToInstantiate);
    }

    void InstantiateObjects(List<string> objectNames)
    {
        foreach (string objName in objectNames)
        {
            switch (objName)
            {
                case "table":
                    Instantiate(tablePrefab, GetRandomPositionInRoom(), Quaternion.identity);
                    break;
                case "chair":
                    int numberOfChairs = Random.Range(4, 8); // Generate between 4 to 7 chairs
                    for (int i = 0; i < numberOfChairs; i++)
                    {
                        Instantiate(chairPrefab, GetRandomPositionInRoom(), Quaternion.identity);
                    }
                    break;
                case "window":
                    Instantiate(windowPrefab, GetRandomPositionInRoom(), Quaternion.identity);
                    break;
                default:
                    break;
            }
        }
    }

    Vector3 GetRandomPositionInRoom()
    {
        float x = Random.Range(-roomWidth / 2, roomWidth / 2);
        float y = 0.5f; // Adjust the height as needed
        float z = Random.Range(-roomLength / 2, roomLength / 2);

        return new Vector3(x, y, z);
    }
}
