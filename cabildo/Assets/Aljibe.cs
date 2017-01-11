using UnityEngine;
using System.Collections;

public class Aljibe : MonoBehaviour {
    
    public Animator soga;

    public Animator mate1;
    public Animator mate2;
    public Animator matenegro;
    public ParticleSystem splashPS;

    public GameObject hint_mate;
    public GameObject hint_soga;
    public GameObject hint_aljibe;

    public Animator aljibe;
    

    void OnEnable()
    {
        Events.OnClick += OnClick;
        Events.OnMinigameReady += OnMinigameReady;
        ResetAllGames();
    }
    void OnDisable()
    {
        Events.OnClick -= OnClick;
        Events.OnMinigameReady -= OnMinigameReady;
    }
    void ResetAllGames()
    {
        soga.Play("idle");
        mate1.Play("idle");
        mate2.Play("idle");
        matenegro.Play("idle");

        hint_mate.SetActive(true);
        hint_soga.SetActive(true);
        hint_aljibe.SetActive(true);

        aljibeOpened = false;
        splashPS.gameObject.SetActive(false);
    }
    void OnClick(Vector3 pos, string clicked)
    {

    }
    void OnMinigameReady()
    {
        Events.OnMinigameBanioReady();
        ResetAllGames();
    }
    bool isSogaOn;
    public void SogaSwipeState()
    {
        hint_soga.SetActive(false);
        isSogaOn = !isSogaOn;
        if (isSogaOn)
            soga.Play("jump");
        else
            soga.Play("idle");
    }
    bool aljibeOpened;
    public void AljibeClicked()
    {
        hint_aljibe.SetActive(false);
        if (!aljibeOpened)
        {
            aljibe.Play("open");
            aljibeOpened = true;
            Events.OnGloboSimpleAbajo(new Vector2(-320, -360), "negrito-tortugas", 6);
        } else
        {
            splashPS.gameObject.SetActive(true);
            splashPS.Play();
        }
    }

    bool drinkingMate;
    int mateID;
    public void Mate(int id)
    {
        hint_mate.SetActive(false);
        if (!drinkingMate)
        {
            matenegro.Play("mate_on");
            mateID = id;
            Invoke("Servido", 2);
        }
        else
        {
            mateID = 0;
            if (id == 1)
                mate1.Play("idle");
            else
                mate2.Play("idle");
        }
        drinkingMate = !drinkingMate;
    }
    void Servido()
    {
        if (mateID == 0)
            return;
        
        if (mateID == 1)
            mate1.Play("drink");
        else if (mateID == 2)
            mate2.Play("drink");

        Invoke("ResetMate", 3);
    }
    void ResetMate()
    {
        if (mateID == 0)
            return;

        mateID = 0;
        drinkingMate = false;
        mate1.Play("idle");
        mate2.Play("idle");
    }
}