using UnityEngine;
using System.Collections;

public class UIPerinola : MonoBehaviour {

    public GameObject playEquipo1;
    public GameObject playEquipo2;
    public int teamId;
    public Perinola game;
	public GameObject ganador1;
	public GameObject ganador2;

    void OnEnable()
    {
		teamId = 1;
        Restart();
		ganador1.SetActive (false);
		ganador2.SetActive (false);
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
	public void Gana(int id)
	{
		if(id==1)
			ganador1.SetActive(true);
		else
			ganador2.SetActive(true);
	}
    
}
