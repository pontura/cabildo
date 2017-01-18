using UnityEngine;
using System.Collections;

public class UIPerinola : MonoBehaviour {

    public GameObject playEquipo1;
    public GameObject playEquipo2;
    public int teamId;
    public Perinola game;

    void OnEnable()
    {
        teamId = 1;
        Restart();
    }
    public void Restart()
    {        
        if (teamId == 1)
            teamId = 2;
        else
            teamId = 1;

        SetButtons();
    }
    void SetButtons()
    {
        switch(teamId)
        {
            case 1:
                playEquipo1.SetActive(true);
                playEquipo2.SetActive(false);
                break;
           default:
                playEquipo2.SetActive(true);
                playEquipo1.SetActive(false);
                break;
        }
    }
    public void PlayEquipo(int id)
    {
        ResetButtons();
        game.OnPerinola();
    }
    void ResetButtons()
    {
        playEquipo2.SetActive(false);
        playEquipo1.SetActive(false);
    }
    
}
