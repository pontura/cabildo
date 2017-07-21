using UnityEngine;
using System.Collections;
using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using SimpleJSON;
public class Convesaciones : MonoBehaviour {

    public ConversationActive conversation;
    public string result = "";
 //   private string pathPreFix = @"file://";
	private string pathPreFix = "D:/cabildo/cabildo/";

    public List<Conversacion> conversaciones;

    [Serializable]
    public class Tema
    {
       
        public string persona;
        public string frase;
    }
    [Serializable]
    public class Dialogos
    {
        public List<Tema> temas;
    }
    [Serializable]
    public class Conversacion
    {        
        public string characters;
        public List<Dialogos> dialogos;
        public List<Vector2> positions;
    }
    void Start()
    {
        StartCoroutine(Example());
    }
    IEnumerator Example()
    {
		pathPreFix = "file://" + Application.dataPath + "/../";
        string filePath = pathPreFix + "conversaciones.json";
		print (filePath);
        WWW www = new WWW(filePath);

        yield return www;
        result = www.text;
        LoadDataromServer(result);
    }
    public void LoadDataromServer(string json_data)
    {
		print (json_data);
        var Json = SimpleJSON.JSON.Parse(json_data);
        fillArray(Json);
    }
    private void fillArray(JSONNode content)
    {

            AddConversacion("mujeres", content[0]["aljibe"]);
            AddConversacion("soga", content[0]["aljibe"]);

            AddConversacion("cantina", content[0]["pulperia"]);
            AddConversacion("bebedores", content[0]["pulperia"]);
           // AddConversacion("guitarrista", content[0]["pulperia"]);

		AddSimpleConversacion("personas", content[0]["caminantes"]);
           
    }
    void AddConversacion(string characters, JSONNode content)
    {        
        Conversacion conversacion = new Conversacion();
        conversacion.characters = characters;
        conversacion.dialogos = new List<Dialogos>();
        JSONNode options = (JSONNode)(content[characters]);
        for (int a = 0; a < options.Count; a++)
        {
            Dialogos dialogos = new Dialogos();
            dialogos.temas = new List<Tema>();
            JSONNode temas = (JSONNode)(options[a]);

            for (int b = 0; b < temas.Count; b++)
            {
                Tema tema = new Tema();
                tema.persona = temas[b]["persona"];
                tema.frase = temas[b]["frase"];
                dialogos.temas.Add(tema);
            }
            conversacion.dialogos.Add(dialogos);
        }
        conversaciones.Add(conversacion);

    }
	void AddSimpleConversacion(string characters, JSONNode content)
	{        
		Conversacion conversacion = new Conversacion();
		conversacion.characters = characters;
		conversacion.dialogos = new List<Dialogos>();
		JSONNode options = (JSONNode)(content[characters]);
		for (int a = 0; a < options.Count; a++)
		{
			Dialogos dialogos = new Dialogos();
			dialogos.temas = new List<Tema>();
			JSONNode temas = (JSONNode)(options[a]);
			Tema tema = new Tema();
			tema.persona = temas["persona"];
			tema.frase = temas["frase"];
			dialogos.temas.Add(tema);
			conversacion.dialogos.Add(dialogos);
		}
		conversaciones.Add(conversacion);
	}
	public string GetSimpleText(string character)
	{
		foreach (Conversacion c in conversaciones) {
			if (c.characters == "personas") {
				foreach (Dialogos d in c.dialogos) {
					if (d.temas [0].persona == character)
						return d.temas [0].frase;
				}
			}
		}
		return "";
	}
    public List<Dialogos> GetDialogo(string characters, int id)
    {
        foreach(Conversacion conv in conversaciones)
        {
            if(conv.characters == characters)
                return conv.dialogos;
        }
        Debug.LogError("No hay conversaciones para: " + characters);
        return null;    
    }

    public void SetDialogosOn(string characters, Vector2 pos1, Vector2 pos2)
    {
        foreach (Conversacion conv in conversaciones)
        {
            if (conv.characters == characters)
            {
                if (conv.positions == null)
                {
                    conv.positions = new List<Vector2>();
                    conv.positions.Clear();
                    conv.positions.Add(pos1);
                    conv.positions.Add(pos2);
                }

                ConversationActive newConversation = Instantiate(conversation);
                newConversation.Init(characters, conv);
            }
        }
    }
}
