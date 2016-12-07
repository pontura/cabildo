using UnityEngine;
using System.Collections;
using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using SimpleJSON;

public class Texts : MonoBehaviour
{
    public string result = "";
    private string pathPreFix = @"file://";

    public List<DataContent> data;

    [Serializable]
    public class DataContent
    {
        public string id;
        public string text;
    }
    void Start()
    {
        StartCoroutine(Example());
    }
    IEnumerator Example()
    {
        string filePath = pathPreFix + "texts.json";
        WWW www = new WWW(filePath);
        yield return www;
        result = www.text;
        LoadDataromServer(result);
    }
    public void LoadDataromServer(string json_data)
    {
        var Json = SimpleJSON.JSON.Parse(json_data);
        fillArray(Json);
    }
    private void fillArray(JSONNode content)
    {
        for (int a = 0; a < content.Count; a++)
        {
            DataContent dataContent = new DataContent();
            dataContent.id = content[a]["id"];
            dataContent.text = content[a]["text"];
            data.Add(dataContent);
        }
    }
    public string GetContent(string textID)
    {
       foreach(DataContent content in data)
            if (content.id == textID)
                return content.text;
        Debug.Log("NO EXISTE UN TEXTO PATA : " + textID);
        return null;
    }
}
