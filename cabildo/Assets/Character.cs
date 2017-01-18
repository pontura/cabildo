using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

    private Animator anim;
    public states state;
    private Vector3 scale;
    private Vector3 pos;

    public enum states
    {
        IDLE,
        WALK
    }
    void Start()
    {
        scale = transform.localScale;
        pos = transform.localPosition;
        anim = GetComponent<Animator>();
    }
    public void Restart()
    {
        transform.localScale = scale;
        transform.localPosition = pos;
        Idle();
    }
    public void Idle()
    {
        anim.Play("idle_1");
    }
	public void Walk()
    {
        anim.Play("walk_1");
    }
}
