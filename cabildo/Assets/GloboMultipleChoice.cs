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

    public void Init(Texts.MultipleChoice mc)
    {
        Utils.RemoveAllChildsIn(container);  
       
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
        Events.OnClick(transform.position,  onClick[sb.id]);
    }
}
