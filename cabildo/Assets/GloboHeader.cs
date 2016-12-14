using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GloboHeader : MonoBehaviour
{
    public Text titleField;
    public Text field;
    private Animation anim;
    public AnimationClip openAnim;
    public AnimationClip closeAnim;
    public states state;
    public enum states
    {
        OFF,
        ON
    }

    void Start()
    {
        anim = GetComponent<Animation>();
        Events.OnHeaderOff += OnHeaderOff;
    } 
    void OnHeaderOff()
    {
        if (state == states.OFF) return;
        state = states.OFF;
        anim.clip = closeAnim;
        anim.Play();
    }
    public void Init(Texts.SimpleContent content)
    {
        state = states.ON;
        anim.clip = openAnim;
        anim.Play();
        titleField.text = content.title;
        field.text = content.text;
    }
    public void Close()
    {
        OnHeaderOff();
    }
}
