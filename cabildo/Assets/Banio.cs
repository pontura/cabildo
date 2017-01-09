using UnityEngine;
using System.Collections;

public class Banio : MonoBehaviour {

    public BanioProgress banioProgress;
    public Animator[] flores;
    public int id;

    void OnEnable()
    {
        id = 0;
        foreach(Animator anim in flores)
            anim.Play("off");

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
    }
    void OnClick(Vector3 pos, string clicked)
    {       
        switch (clicked)
        {
            case "BanioBtn":
                if (id > flores.Length - 1) return;

                banioProgress.PlayAnim("progreso", 0.9f);
                flores[id].Play("on");
                id++;
                break;
        }
    }
    void OnMinigameReady()
    {
        Events.OnMinigameBanioReady();
        ResetAllGames();
    }
}
