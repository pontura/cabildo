using UnityEngine;
using System.Collections;

public class Bochas : MonoBehaviour {
    void OnEnable()
    {
		print ("OnEnable");
        Events.OnClick += OnClick;
        Events.OnMinigameReady += OnMinigameReady;
        ResetAllGames();
    }
    void OnDisable()
    {
		print ("OnDisable");
        Events.OnClick -= OnClick;
        Events.OnMinigameReady -= OnMinigameReady;
    }
    void ResetAllGames()
    {

    }
    void OnClick(Vector3 pos, string clicked)
    {

    }
    void OnMinigameReady()
    {
		print ("OnMinigameReady");
		Events.OnMinigameBanioReady();
		Events.OnMinigameBochasReady();
        ResetAllGames();
    }

}
