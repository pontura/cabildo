using UnityEngine;
using System.Collections;

public class CasaPudiente : MonoBehaviour {

    public Character negrito;
    public Character aguatero;
    public Character lechero;

    private Animator anim;

    public states state;
    public enum states
    {
        IDLE,
        WATER,
        MILK
    }

	void Start () {
        anim = GetComponent<Animator>();
        Events.OnClick += OnClick;

        negrito.WalkEmpty();
        anim.Play("start");
    }
    public void Idle()
    {
        negrito.IdleNormal();
        state = states.IDLE;
    }
    void OnClick(Vector3 pos, string name)
    {
        if(name == "Sirviente")
        {
            if(state == states.IDLE)
                Events.OnGloboMultipleChoice(new Vector3(-312.88f, -25.61f, 0), "negrito");
        }
        else if(name == "negrito-agua")
        {
            Water();
        }
        else if (name == "negrito-leche")
        {
            Milk();
        }
    }
    public void NegritoStart()
    {
        negrito.WalkEmpty();
    }
    public void Water()
    {
        state = states.WATER;
        Events.ConversationKill("negrito");
        anim.Play("buyWater");
        Invoke("aguatero_walk", 0.2f);
    }
    void aguatero_walk()
    {
        aguatero.WalkNormal();
    }

    public void Milk()
    {
        state = states.MILK;
        Events.ConversationKill("negrito");
        anim.Play("buyMilk");
        Invoke("lechero_walk", 0.2f);
    }
    void lechero_walk()
    {
        lechero.WalkNormal();
    }

    public void StartBuyingWater()
    {
        negrito.Buy("water");
        aguatero.Sell();
        Invoke("FinishBuying", 0.8f);
    }
    void FinishBuying()
    {
        negrito.WalkFull();
    }
    public void StartBuyingMilk()
    {
        negrito.Buy("milk");
        lechero.Sell();
        Invoke("FinishBuying", 0.8f);
    }
}
