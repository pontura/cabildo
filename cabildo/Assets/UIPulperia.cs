using UnityEngine;
using System.Collections;

public class UIPulperia : MonoBehaviour {

    public Transform globo_servidor;

    public Transform globo_bebedor1;
    public Transform globo_bebedor2;

    public Transform globo_guitarrista;
    public Transform globo_guitarrista2;

    public GameObject hint_toma;
    public GameObject hint_bebedores;
    public GameObject hint_guitarra;

    public Animator toma1;
    public Animator toma2;
    public Animator tomaSirve;
    public Animator guitarrista;
    public Animator[] publico;
    public Animator[] bebedor;

    void OnEnable () {
        Reset();
        tomaSirve.Play("glassOn");
        hint_toma.SetActive(true);
        hint_guitarra.SetActive(true);
        hint_bebedores.SetActive(true);


        DiceCantinero(1);
        BebedoresHabla();
        GuitarraHabla();
    }
    void OnDisable()
    {
        Reset();
    }
    void Reset()
    {
        Events.ConversationKill("cantina");
        Events.ConversationKill("bebedores");
        Events.ConversationKill("guitarrista");
    }
    public void Bebedores()
    {
        hint_bebedores.SetActive(false);
        foreach (Animator anim in bebedor)
            anim.Play("drink");
    }
    public void Guitarra()
    {
		Events.OnSFX(Data.Instance.sFXManager.guitar);

        hint_guitarra.SetActive(false);
        guitarrista.Play("play");
        foreach (Animator anim in publico)
            anim.Play("dance");
		Invoke ("Applause", 2f);
    }
	void Applause()
	{
		Events.OnSFX(Data.Instance.sFXManager.applause);
	}
    bool drinking;
    int mateID;
    public void Toma(int id)
    {
        hint_toma.SetActive(false);
        if (!drinking)
        {
            if (id == 1)
                DiceCantinero(3);
            else
                DiceCantinero(2);

            tomaSirve.Play("serve");
            mateID = id;
            Invoke("Servido", 2);
        }
        else
        {
            mateID = 0;
            if (id == 1)
                toma1.Play("idle");
            else
                toma2.Play("idle");
        }
        drinking = !drinking;
    }
    bool talking;
    float resetTalkTime;
    void DiceCantinero(int id)
    {
        resetTalkTime = Time.time+3;
        talking = true;
        Events.OnGloboSimpleOff("cantina");
        string field = "";
        switch(id)
        {
            case 1:
                field = Data.Instance.texts.GetContent("cantina-pregunta"); break;
            case 2:
                field = Data.Instance.texts.GetContent("cantina-esclavo"); break;
            case 3:
                field = Data.Instance.texts.GetContent("cantina-amigo"); break;
        }
        Events.OnGloboSimple("cantina", globo_servidor.localPosition + transform.localPosition, field);
        Invoke("ResetGlobo", 3);
    }
    void Update()
    {
        if (!talking) return;
        if (Time.time>resetTalkTime)
        {
            Events.OnGloboSimpleOff("cantina");
            talking = false;
        }
    }
    void Servido()
    {
        if (mateID == 0)
            return;

        if (mateID == 1)
            toma1.Play("drink");
        else if (mateID == 2)
            toma2.Play("drink");

        Invoke("ResetMate", 3);
    }
    void ResetMate()
    {
        if (mateID == 0)
            return;

        mateID = 0;
        drinking = false;
        toma1.Play("idle");
        toma2.Play("idle");
    }
    void BebedoresHabla()
    {
        Vector2 pos1 = globo_bebedor1.transform.localPosition + transform.localPosition;
        Vector2 pos2 = globo_bebedor2.transform.localPosition + transform.localPosition;
        Data.Instance.conversaciones.SetDialogosOn("bebedores", pos1, pos2);
    }
    void GuitarraHabla()
    {
        Vector2 pos1 = globo_guitarrista.transform.localPosition + transform.localPosition;
        Vector2 pos2 = globo_guitarrista2.transform.localPosition + transform.localPosition;
        Data.Instance.conversaciones.SetDialogosOn("guitarrista", pos1, pos2);
    }
}
