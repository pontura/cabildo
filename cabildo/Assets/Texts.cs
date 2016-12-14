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

    public List<SimpleContent> simpleContents;
    public List<MultipleChoice> multipleChoices;

    public types type;
    public enum types
    {
        NONE,
        SIMPLE,
        MULTIPLECHOICE
    }

    [Serializable]
    public class SimpleContent
    {
        public string id;
        public string title;
        public string text;
    }
    [Serializable]
    public class MultipleChoice
    {
        public string id;
        public string title;
        public List<string> options;
        public List<string> onClick;
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
            if (content[a]["text"] != null)
                AddSimpleContent(content[a]);
            else if (content[a]["multiple-choice"] != null)
                AddMultipleChoice(content[a]);
        }
    }
    void AddSimpleContent(JSONNode content)
    {
        SimpleContent dataContent = new SimpleContent();
        dataContent.id = content["id"];
        dataContent.title = content["title"];
        dataContent.text = content["text"];
        simpleContents.Add(dataContent);
    }
    void AddMultipleChoice(JSONNode content)
    {
        MultipleChoice dataContents = new MultipleChoice();
        dataContents.id = content["id"];
        dataContents.title = content["multiple-choice"]["title"];

        dataContents.options = new List<string>();
        JSONNode options = (JSONNode)(content["multiple-choice"]["options"]);
        for (int a = 0; a< options.Count; a++)
            dataContents.options.Add(options[a]);

        dataContents.onClick = new List<string>();
        JSONNode onClick = (JSONNode)(content["multiple-choice"]["onClick"]);
        for (int a = 0; a < onClick.Count; a++)
            dataContents.onClick.Add(onClick[a]);

        multipleChoices.Add(dataContents);
    }
    public string GetContent(string textID)
    {
       foreach(SimpleContent content in simpleContents)
            if (content.id == textID)
                return content.text;
        Debug.Log("NO EXISTE UN TEXTO PATA : " + textID);
        return null;
    }
    public SimpleContent GetSimpleContentData(string id)
    {
        foreach (SimpleContent c in simpleContents)
            if (c.id == id)
                return c;
        return null;
    }
    public MultipleChoice GetMultipleChoiceData(string id)
    {
        foreach (MultipleChoice c in multipleChoices)
            if (c.id == id)
                return c;
        return null;
    }
}
