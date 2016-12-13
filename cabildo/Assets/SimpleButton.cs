using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SimpleButton : MonoBehaviour {

    public int id;
    public Text field;

	public void Init(int id, string text) {
        this.id = id;
        field.text = text;
    }
}
