using UnityEngine;
using System.Collections;

public class Iglesia : MonoBehaviour {

    public Character HombreRico1;
    public Character MujerRica1;

    private Animation anim;

    public states state;
    public enum states
    {
        IDLE,
        ACTIVE
    }

    void Start () {
        anim = GetComponent<Animation>();
        Events.OnClick += OnClick;
    }	
    void OnClick(Vector3 pos, string title)
    {
        if (state == states.IDLE && title == "iglesia")
            SetActive();
    }
    void SetActive()
    {
        state = states.ACTIVE;
        anim.Play("active");
        Invoke("Idle", 10);
    }
    void Idle()
    {
        state = states.IDLE;
        anim.Play("idle");
        MujerRica1.Restart();
        HombreRico1.Restart();
    }
    public void Walk_Ricos()
    {
        MujerRica1.Walk();
        HombreRico1.Walk();
    }
}
