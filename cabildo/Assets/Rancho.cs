using UnityEngine;
using System.Collections;

public class Rancho : MonoBehaviour {

    public states state;
    public enum states
    {
        IDLE,
        CHINA_WALKING
    }
    Animator anim;
    public SpriteRenderer[] zanahorias;
    public GameObject zanahoriasInHand;
    public Animator china;
    public Animator gauchoRancho;

    public Animator Nadador1;
    public Animator Nadador2;
    public Animator Lavandera1;
    public Animator Lavandera2;

    void Start () {
        anim = GetComponent<Animator>();
        IdleZanahorias();
        Events.OnClick += OnClick;
    }
    void OnDestroy()
    {
        Events.OnClick -= OnClick;
    }
    void OnClick(Vector3 pos, string title)
    {

        if (title == "china" || title == "zanahorias")
            ChinaClicked();
        else if (title == "gauchoRancho")
            GauchoRanchoClicked();

        else if(title == "nadador1")
            Nadador1.Play("splash",0,0);
        else if (title == "nadador2")
            Nadador2.Play("splash", 0, 0);

        else if (title == "lavandera1")
            Lavandera1.Play("wash", 0, 0);
        else if (title == "lavandera2")
            Lavandera2.Play("wash", 0, 0);

    }
    void GauchoRanchoClicked()
    {
        gauchoRancho.Play("drink");
    }
    void IdleZanahorias() {
        state = states.IDLE;
        ResetZanahorias();
        china.Play("idle");
    }

    void WalkIn()
    {
        state = states.CHINA_WALKING;
        anim.Play("walkOut");
        Invoke("IdleZanahorias", 12);
        Invoke("ResetZanagoriasInHand", 7);
        china.Play("walk");
    }

    void ChinaClicked()
    {
        if (state == states.CHINA_WALKING) return;

        foreach (SpriteRenderer sr in zanahorias)
        {
            if (sr.enabled)
            {
                sr.enabled = false;
                GetZanahoria();
                return;
            }
        }
        WalkIn();
    }
    void GetZanahoria()
    {
        foreach (SpriteRenderer sr in zanahoriasInHand.GetComponentsInChildren<SpriteRenderer>())
        {
            if (!sr.enabled)
            {
                sr.enabled = true;
                return;
            }
        }
    }
    void ResetZanahorias()
    {
        foreach (SpriteRenderer sr in zanahorias)
            sr.enabled = true;

        ResetZanagoriasInHand();
    }
    void ResetZanagoriasInHand()
    {
        foreach (SpriteRenderer sr in zanahoriasInHand.GetComponentsInChildren<SpriteRenderer>())
            sr.enabled = false;
    }
}
