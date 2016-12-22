using UnityEngine;
using System.Collections;

public class Cocina : MonoBehaviour {

    public CocinaCortarAnim zanahoria;
    public CocinaCortarAnim arroz;

    public UICocina uiCocina;

    public minigames minigame;
    public enum minigames
    {
        NONE,
        ZAPALLO,
        PAPAS,
        CEBOLLA,
        ACEITE,
        SAL,
        ZANAHORIA,
        ARROZ,
        POROTOS
    }

	void OnEnable () {
        Events.OnClick += OnClick;
        Events.OnMinigameReady += OnMinigameReady;
    }
    void OnDisable()
    {
        Events.OnClick -= OnClick;
        Events.OnMinigameReady -= OnMinigameReady;
    }
    void OnMinigameReady()
    {
        print("OnMinigameReady " + minigame);
        Events.OnMinigameCocinaReady(minigame);
    }
    void OnClick(Vector3 pos, string clicked)
    {
        if (minigame == minigames.NONE)
        {
            switch (clicked)
            {
                case "zanahoria":
                    if (CheckIfAvailableSelectIngrediente(minigames.ZANAHORIA))
                    {
                        minigame = minigames.ZANAHORIA;
                        zanahoria.gameObject.SetActive(true);
                    }
                    break;
            }
        }           
        else
        {
            switch (clicked)
            {
                case "haceArroz":
                    arroz.PlayAnim("haceArroz");
                    break;
                case "corteZanahoria":
                    zanahoria.PlayAnim("corteZanahoria");
                    break;
            }
        }
    }
    bool CheckIfAvailableSelectIngrediente(minigames ingrediente)
    {       
        if (uiCocina.IsReady(minigame))
        {
            print("READY");
            return false;
        }
        else if (!uiCocina.IsInTheReceta(minigame))
        {
            print("No esta en la receta");
            return false;
        }
        return true;
    }
}
