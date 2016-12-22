using UnityEngine;
using System.Collections;

public class CocinaCortarAnim : MonoBehaviour {

    private Animator anim;
    private bool ready;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void OnEnable()
    {
        ready = false;
        anim.playbackTime = 0;
        anim.speed = 1;
    }	
    public void PlayAnim(string animName)
    {
        if (ready) return;
        anim.Play(animName);
        anim.speed = 1;
        AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);
        float playbackTime = info.normalizedTime % 1;
        if (playbackTime > 0.8f)
            Ready();
        print(" animName : " + animName + " time : " + playbackTime);
    }
    void Ready()
    {
        ready = true;
        Invoke("ReadyDelay", 1);
    }
    void ReadyDelay()
    {
        Events.OnMinigameReady();
    }
    public void PauseAnim()
    {
        if (ready) return;
        print("PauseAnim   ");
        anim.speed = 0;
    }
}
