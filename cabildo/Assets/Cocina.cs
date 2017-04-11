using UnityEngine;
using System.Collections;

public class Cocina : MonoBehaviour {

    public CocinaCortarAnim zapallo;
    public CocinaCortarAnim papas;
    public CocinaCortarAnim cebolla;
    public CocinaCortarAnim aceite;
    public CocinaCortarAnim sal;
    public CocinaCortarAnim zanahoria;
    public CocinaCortarAnim arroz;
    public CocinaCortarAnim porotos;

    public UICocina uiCocina;
    public Vector2 mulataPos;

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
        POROTOS,
        READY,
        COMPLETE
    }

	void OnEnable () {
        uiCocina.VerRecetaButtonOn();
        minigame = minigames.NONE;
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
        zapallo.gameObject.SetActive(false);
        papas.gameObject.SetActive(false);
        cebolla.gameObject.SetActive(false);
        aceite.gameObject.SetActive(false);
        sal.gameObject.SetActive(false);
        zanahoria.gameObject.SetActive(false);
        arroz.gameObject.SetActive(false);
        porotos.gameObject.SetActive(false);
    }
    void OnClick(Vector3 pos, string clicked)
    {
        if (minigame == minigames.COMPLETE)
        {
			print("cocina minigames.COMPLETE: " + clicked);
            switch (clicked)
            {
                case "mulata-otra":
                    minigame = minigames.NONE;
                    Events.ResetGlobos();
                    uiCocina.VerRecetaButtonOn();
					uiCocina.EmptyAllRecetas();
                    break;
                case "mulata-done":
					minigame = minigames.NONE;
                    Events.ResetGlobos();
					uiCocina.EmptyAllRecetas();
                    Events.ResetPopup(GlobosManager.sides.LEFT);
                    break;
            }
            return;
        }
        if (minigame == minigames.READY) return;

        if (minigame == minigames.NONE)
        {
			print("cocina minigames.NONE: " + clicked);
            switch (clicked)
            {
				case "mulata-otra":
					Events.ResetGlobos ();
					break;
				case "mulata-done":
					Events.ResetGlobos ();
                    break;
				case "aceite":
					if (CheckIfAvailableSelectIngrediente(minigames.ACEITE))
					{
						minigame = minigames.ACEITE;
						InitGame(aceite.gameObject);
					}
					break;
                case "papas":
                    if (CheckIfAvailableSelectIngrediente(minigames.PAPAS))
                    {
                        minigame = minigames.PAPAS;
                        InitGame(papas.gameObject);
                    }
                    break;
                case "arroz":
                    if (CheckIfAvailableSelectIngrediente(minigames.ARROZ))
                    {
                        minigame = minigames.ARROZ;
                        InitGame(arroz.gameObject);
                    }
                    break;
                case "zanahoria":
                    if (CheckIfAvailableSelectIngrediente(minigames.ZANAHORIA))
                    {
                        minigame = minigames.ZANAHORIA;
                        InitGame(zanahoria.gameObject);
                    }
                    break;
                case "zapallo":
                    if (CheckIfAvailableSelectIngrediente(minigames.ZAPALLO))
                    {
                        minigame = minigames.ZAPALLO;
                        InitGame(zapallo.gameObject);
                    }
                    break;
                case "porotos":
                    if (CheckIfAvailableSelectIngrediente(minigames.POROTOS))
                    {
                        minigame = minigames.POROTOS;
                        InitGame(porotos.gameObject);
                    }
                    break;
                case "cebollas":
                    if (CheckIfAvailableSelectIngrediente(minigames.CEBOLLA))
                    {
                        minigame = minigames.CEBOLLA;
                        InitGame(cebolla.gameObject);
                    }
                    break;
                case "sal":
                    if (CheckIfAvailableSelectIngrediente(minigames.SAL))
                    {
                        minigame = minigames.SAL;
                        InitGame(sal.gameObject);
                    }
                    break;
            }
        }           
        else
        {
            switch (clicked)
            {
                case "hace_aceite":
                    aceite.PlayAnim("tirarAceite", 0f, 3);
                    break;
                case "hace_papa":
                    papas.PlayAnim("cortePapa", 0.5f, 2);
                    break;
                case "hace_arroz":
                    arroz.PlayAnim("tirarArroz", 0.6f);
                    break;
                case "hace_zanahoria":
                    zanahoria.PlayAnim("corteZanahoria", 0.8f);
                    break;
                case "hace_zapallo":
                    zapallo.PlayAnim("corteZapallo", 0.4f);
                    break;
                case "hace_porotos":
                    porotos.PlayAnim("tirarPorotos", 0.4f);
                    break;
                case "hace_cebolla":
                    cebolla.PlayAnim("cortarCebolla", 0.7f);
                    break;
                case "hace_sal":
                    sal.PlayAnim("tirarSal", 0.4f, 2);
                    break;
            }
        }
    }
    void InitGame(GameObject go)
    {
        go.gameObject.SetActive(true);
        uiCocina.VerRecetaButtonOff();
    }
    void OnMinigameReady()
    {    
        Events.OnMinigameCocinaReady(minigame);        
        ResetAllGames();
        
        if (uiCocina.CheckRecetaReady())
        {
            Vector2 pos = mulataPos;
            pos.y += 180;
            Events.OnGloboMultipleChoice(pos, "mulata_fin");
            minigame = minigames.COMPLETE;
        }
        else
        {
            OpenGloboSimpleAbajo("mulata_felicita_por_ingrediente");
            minigame = minigames.READY;
        }
    }
    bool CheckIfAvailableSelectIngrediente(minigames minigame)
    {
        print("CheckIfAvailableSelectIngrediente" + minigame);
         
        if (uiCocina.IsReady(minigame))
        {
            OpenGloboSimpleAbajo("mulata_tiene_ingrediente");
            return false;
        }
        else if (!uiCocina.IsInTheReceta(minigame))
        {
            OpenGloboSimpleAbajo("mulata_no_necesita_ingrediente");
            return false;
        }
        return true;
    }    
    void OpenGloboSimpleAbajo(string text)
    {
        Events.OnGloboSimpleAbajo(mulataPos, text, 3);
        uiCocina.VerRecetaButtonOff();
        Invoke("VerRecetaButtonOn", 2);
    }
    void VerRecetaButtonOn()
    {
        uiCocina.VerRecetaButtonOn();
        //uiCocina.IngredienteReady();
        if(minigame == minigames.READY)
            minigame = minigames.NONE;
    }
    
}
