using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GloboMultipleChoice : MonoBehaviour
{
    public Text field;
    public SimpleButton simpleButton;
    public Transform container;
    List<string> onClick;

    public void Init(string text)
    {
        Utils.RemoveAllChildsIn(container);       
        
        Texts.MultipleChoice mc = Data.Instance.texts.GetMultipleChoiceData(text);
        field.text = mc.title;
        this.onClick = mc.onClick;

        int id = 0;
        foreach (string option in mc.options)
        {
            SimpleButton sButton = Instantiate(simpleButton);
            sButton.GetComponent<Button>().onClick.AddListener(() => { TaskOnClick(sButton); });
            sButton.Init(id, option);
            sButton.transform.SetParent(container);
            id++;
        }
    }
    public void TaskOnClick(SimpleButton sb)
    {
        Events.OnGloboDialogo(transform.position,  onClick[sb.id]);
    }
}
