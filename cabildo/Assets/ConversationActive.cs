using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ConversationActive : MonoBehaviour {

    public string characters;
    public Convesaciones.Conversacion conversation;
    public int dialogo_id = 0;
    public int frase_id = 0;

    void Start()
    {
        Events.ConversationKill += ConversationKill;
    }
    void OnDestroy()
    {
        Events.ConversationKill -= ConversationKill;
    }
    void ConversationKill(string _characters)
    {
        if (characters == _characters)
            Destroy(gameObject);
    }
    public void Init(string characters, Convesaciones.Conversacion conversation)
    {
        this.characters = characters;
        this.conversation = conversation;

        dialogo_id = Random.Range(0, conversation.dialogos.Count - 1);

        Invoke("Dice", Random.Range(2, 5));
    }
    void Dice()
    {
        string frase = conversation.dialogos[dialogo_id].temas[frase_id].frase;

        Vector2 pos = conversation.positions[0];
        switch (conversation.dialogos[dialogo_id].temas[frase_id].persona)
        {
            case "B": pos = conversation.positions[1]; break;
        }        
        Events.OnGloboSimple(characters, pos, frase);
        Invoke("Next", Random.Range(5, 8));
    }
    void Next()
    {
        int timer = Random.Range(1, 3);
        frase_id++;
        if (frase_id > conversation.dialogos[dialogo_id].temas.Count-1)
        {
            frase_id = 0;
            dialogo_id++;
            timer += Random.Range(4, 7);
            if (dialogo_id > conversation.dialogos.Count - 1)
                dialogo_id = 0;
        }        
        Events.OnGloboSimpleOff(characters);
        Invoke("Dice", timer);
    }
}
