using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class UIAljibe : MonoBehaviour {

    public Aljibe aljibe;
    public Transform globo_mate1;
    public Transform globo_mate2;
    public Transform globo_mate_negro;
    public Transform globo_salta1;
    public Transform globo_salta2;
    public Transform globo_salta3;

    void OnEnable()
    {
        Reset();
        MateHabla();
        NinosHablan();
    }
    void OnDisable()
    {
        Reset();        
    }
    void Reset()
    {
        Events.OnGloboSimpleOff("mujeres");
        Events.ConversationKill("mujeres");

        Events.OnGloboSimpleOff("negrito-tortugas");
        Events.OnGloboSimpleOff("soga");
        Events.ConversationKill("soga");
    }
    public void SogaSwipeState()
    {
        aljibe.SogaSwipeState();
    }
    public void AljibeClicked()
    {
        aljibe.AljibeClicked();
    }
    public void Mate(int id)
    {
        aljibe.Mate(id);
    }
    void MateHabla()
    {
        Vector2 pos1 = globo_mate1.transform.localPosition + transform.localPosition;
        Vector2 pos2 = globo_mate2.transform.localPosition + transform.localPosition;
        Data.Instance.conversaciones.SetDialogosOn("mujeres", pos1, pos2);        
    }
    void NinosHablan()
    {
        Vector2 pos1 = globo_salta1.transform.localPosition + transform.localPosition;
        Vector2 pos2 = globo_salta3.transform.localPosition + transform.localPosition;
        Data.Instance.conversaciones.SetDialogosOn("soga", pos1, pos2);
    }
}
