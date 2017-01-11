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
    }
    void OnDisable()
    {
        Events.OnGloboSimpleOff -= OnGloboSimpleOff;
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

}
