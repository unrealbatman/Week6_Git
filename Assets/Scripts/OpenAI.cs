using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine.Networking;

public class OpenAI : MonoBehaviour
{
    private string apiKey = "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";

    public void CreateCompletion(string prompt, System.Action<Response> callback)
    {
        StartCoroutine(GenerateCompletion(prompt, callback));
    }

    IEnumerator GenerateCompletion(string prompt, System.Action<Response> callback)
    {
        string url = "https://api.openai.com/v1/engines/davinci/completions";
        string jsonString = "{\"prompt\": \"" + prompt + "\", \"max_tokens\": 150}";

        using UnityWebRequest webRequest = new(url, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonString);
        webRequest.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        webRequest.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        webRequest.SetRequestHeader("Content-Type", "application/json");
        webRequest.SetRequestHeader("Authorization", "Bearer " + apiKey);

        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.ConnectionError ||
            webRequest.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("Error: " + webRequest.error);
        }
        else
        {
            string responseJson = webRequest.downloadHandler.text;
            Response response = JsonUtility.FromJson<Response>(responseJson);
            callback(response);
        }
    }
}

[System.Serializable]
public class Response
{
    public List<Choice> choices;
}

[System.Serializable]
public class Choice
{
    public string text;
}
