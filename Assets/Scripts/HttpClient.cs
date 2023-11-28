using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public static class HttpClient 
{ 
    public static async Task<T> Get<T>(string endpoint)
    {
        UnityWebRequest getRequest = CreateRequest(endpoint);
        getRequest.SendWebRequest();

        while (!getRequest.isDone) await Task.Delay(10);
        return JsonConvert.DeserializeObject<T>(getRequest.downloadHandler.text);
    }

    public static async Task<T> Post<T>(string endpoint, object payload)
    {
        UnityWebRequest postRequest = CreateRequest(endpoint, RequestType.POST, payload);
        postRequest.SendWebRequest();
        
        while(!postRequest.isDone) await Task.Delay(10);

        if(postRequest.result == UnityWebRequest.Result.Success)
            return JsonConvert.DeserializeObject<T>(postRequest.downloadHandler.text);
        else
        {
            Debug.Log($"Error: {postRequest.error}");
            throw new UnityException(postRequest.error);
        }
    }

    private static UnityWebRequest CreateRequest(string path, RequestType type = RequestType.GET, object data = null)
    {
        UnityWebRequest request = new(path, type.ToString());

        if(data != null)
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(JsonUtility.ToJson(data));
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        }

        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        return request;
    }

    private static void AttachHeader(UnityWebRequest request, string key, string value)
    {
        request.SetRequestHeader(key, value);
    }

    public enum RequestType
    {
        GET,
        POST,
        PUT
    }
}