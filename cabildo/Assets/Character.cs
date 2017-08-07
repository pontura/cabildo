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
        WALK,
        SELL
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
	public void SoundDrop()
	{
		Events.OnSFX (Data.Instance.sFXManager.waterDrop);
	}
	public void SoundBuy()
	{
		Events.OnSFX (Data.Instance.sFXManager.cash);
	}
    public void Idle()
    {
        anim.Play("idle_1");
    }
	public void Walk()
    {
        anim.Play("walk_1");
    }
    public void WalkEmpty()
    {
        anim.Play("walk_empty");
    }
    public void WalkFull()
    {
        anim.Play("walk_full");
    }
    public void Buy(string type)
    {
        switch(type)
        {
            case "water": anim.Play("buy_water");  break;
            case "milk": anim.Play("buy_milk"); break;
        }
    }
    public void WalkNormal()
    {
        state = states.WALK;
        anim.Play("walk");
    }
    public void Sell()
    {
        state = states.SELL;
        anim.Play("sell");
    }
    public void IdleNormal()
    {
        state = states.IDLE;
        anim.Play("idle");
    }
}
