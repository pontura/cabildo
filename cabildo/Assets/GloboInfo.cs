using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GloboInfo : MonoBehaviour
{
    public Text field;

    public void Init(string text)
    {
        field.text = text;
    }

}
