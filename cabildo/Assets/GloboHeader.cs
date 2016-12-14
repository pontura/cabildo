using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GloboHeader : MonoBehaviour
{
    public Text titleField;
    public Text field;    

    public void Init(Texts.SimpleContent content)
    {
        titleField.text = content.title;
        field.text = content.text;
    }
}
