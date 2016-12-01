using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SignalUI : MonoBehaviour {

    public Text field;

	void Start () {
        Events.SetSignalText += SetSignalText;
    }

	void SetSignalText(string text) {
        string content = Data.Instance.texts.GetContent(text);
        field.text = content;
    }
}
