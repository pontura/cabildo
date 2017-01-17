using UnityEngine;
using System.Collections;

public class Pulperia : MonoBehaviour {

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
      
    }
    void OnClick(Vector3 pos, string clicked)
    {

    }
    void OnMinigameReady()
    {
        Events.OnMinigameBanioReady();
        ResetAllGames();
    }

}
