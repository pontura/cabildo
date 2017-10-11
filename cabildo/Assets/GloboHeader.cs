using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GloboHeader : MonoBehaviour
{
    public int id;
    public Text titleField;
    public Text field;
    private Animation anim;
    public AnimationClip openAnim;
    public AnimationClip closeAnim;
    public states state;
	public Scrollbar scrollBar;

    public enum states
    {
        OFF,
        ON
    }

    void Start()
    {
        anim = GetComponent<Animation>();
        Events.OnHeaderOff += OnHeaderOff;
        Events.OnHeader2Off += OnHeader2Off;
    } 
    void OnHeaderOff()
    {
        if (id == 1) return;
        if (state == states.OFF) return;
        state = states.OFF;
        anim.clip = closeAnim;
        anim.Play();
    }
    void OnHeader2Off()
    {
        if (id == 0) return;
        if (state == states.OFF) return;
        state = states.OFF;
        anim.clip = closeAnim;
        anim.Play();
    }
    public void Init(Texts.SimpleContent content)
    {
		scrollBar.value = 1;
        state = states.ON;
        anim.clip = openAnim;
        anim.Play();
        titleField.text = content.title;
        field.text = content.text;
    }
    public void Close()
    {
        if (id == 1)
            OnHeader2Off();
        else
            OnHeaderOff();
    }
}
