using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GloboInfo : MonoBehaviour
{
    public string title;
    public Text field;

    void OnEnable()
    {
        Events.OnGloboSimpleOff += OnGloboSimpleOff;
        Events.ConversationKill += ConversationKill;
    }
    void OnDisable()
    {
        Events.OnGloboSimpleOff -= OnGloboSimpleOff;
        Events.ConversationKill -= ConversationKill;
    }
    void OnGloboSimpleOff(string _title)
    {
        if (title == _title)
            Destroy(gameObject);
    }
    public void Init(string title, string text)
    {
        this.title = title;
        field.text = text;
    }
    public void InitAndReset(string title, string text, int resetTime = 3)
    {
        this.title = title;
        field.text = text;
        Invoke("Reset", resetTime);
    }
    void ConversationKill(string _title)
    {
        if (title == _title) Reset();
    }
    void Reset()
    {
        if(gameObject != null)
            Destroy(gameObject);
    }

}
