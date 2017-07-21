using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class UICocina : MonoBehaviour {
    
	public GameObject popupLeft;
    public GameObject globoReceta;
    public GameObject globoVerReceta;

    public GameObject carbonada;
    public GameObject locro;
    public GameObject puchero;

    public recetas receta;
    public enum recetas
    {
        CARBONADA,
        LOCRO,
        PUCHERO
    }
    [Serializable]
    public class RecetaLine
    {
        public Cocina.minigames ingrediente;
        public bool ready;
        public Image readyImage;
    }
    public RecetaLine[] receta_carbonada;
    public RecetaLine[] receta_locro;
    public RecetaLine[] receta_puchero;

    void Next()
    {
        ResetProgress();
        Reset();
        if (receta == recetas.CARBONADA) receta = recetas.LOCRO;
        else if (receta == recetas.LOCRO) receta = recetas.PUCHERO;
        else if (receta == recetas.PUCHERO) receta = recetas.CARBONADA;
    }
    void OnEnable()
    {
        Reset();
        receta = recetas.CARBONADA;
        OnVerReceta(receta);

        Events.OnVerReceta += OnVerReceta;
        Events.OnMinigameCocinaReady += OnMinigameCocinaReady;
    }
    void OnDisable()
    {
        Events.OnVerReceta += OnVerReceta;
        Events.OnMinigameCocinaReady -= OnMinigameCocinaReady;
    }
    void SetReady(RecetaLine[] receta, Cocina.minigames minigame)
    {
        RecetaLine line = GetIngredienteInReceta(receta, minigame);
        if (line == null) return;
        line.ready = true;
        line.readyImage.gameObject.SetActive(true);
    }
	public void EmptyAllRecetas()
	{
		print("_____________ EmptyAllRecetas");
		EmptyReceta(receta_puchero);
		EmptyReceta(receta_locro);
		EmptyReceta(receta_carbonada);
	}
	void EmptyReceta(RecetaLine[] receta)
	{		
		foreach(RecetaLine rl in receta)
			rl.ready = false;
	}
    RecetaLine GetIngredienteInReceta(RecetaLine[] receta, Cocina.minigames minigame)
    {
        print("GetIngredienteInReceta" + receta + " minigame + " + minigame);
        foreach (RecetaLine line in receta)
            if (line.ingrediente == minigame)
                return line;
        return null;
    }
    void OnMinigameCocinaReady(Cocina.minigames minigame)
    {
		print("OnMinigameCocinaReady  minigame + " + minigame);
        switch (receta)
        {
            case recetas.PUCHERO:
                SetReady(receta_puchero, minigame);
                break;
            case recetas.LOCRO:
                SetReady(receta_locro, minigame);
                break;
            case recetas.CARBONADA:
                SetReady(receta_carbonada, minigame);
                break;
        }

    }
    RecetaLine[] GetActualRecetaArray()
    {
        switch (receta)
        {
            case recetas.PUCHERO:
                return receta_puchero;
            case recetas.LOCRO:
                return receta_locro;
            default:
                return receta_carbonada;
        }
    }
    void OnVerReceta(recetas receta)
    {
        this.receta = receta;
        globoVerReceta.gameObject.SetActive(false);
        globoReceta.SetActive(true);
        Reset();
        switch (receta)
        {
            case recetas.LOCRO: locro.SetActive(true); break;
            case recetas.CARBONADA: carbonada.SetActive(true); break;
            case recetas.PUCHERO: puchero.SetActive(true); break;
        }
    }
    public bool IsReady(Cocina.minigames ingrediente)
    {
        switch (receta)
        {
            case recetas.PUCHERO:
                if (GetIngredienteInReceta(receta_puchero, ingrediente) != null && GetIngredienteInReceta(receta_puchero, ingrediente).ready) return true;
                break;
            case recetas.LOCRO:
                if (GetIngredienteInReceta(receta_locro, ingrediente) != null && GetIngredienteInReceta(receta_locro, ingrediente).ready) return true;
                break;
            case recetas.CARBONADA:
                if (GetIngredienteInReceta(receta_carbonada, ingrediente) != null && GetIngredienteInReceta(receta_carbonada, ingrediente).ready) return true;
                break;
        }
        return false;
    }
    public bool IsInTheReceta(Cocina.minigames ingrediente)
    {
        if (GetIngredienteInReceta(GetActualRecetaArray(), ingrediente) == null) return false;
        return true;
    }
    void Reset()
    {
        locro.SetActive(false);
        carbonada.SetActive(false);
        puchero.SetActive(false);
    }
    void ResetProgress()
    {
        foreach (RecetaLine line in receta_locro)
        {
            line.ready = false;
            line.readyImage.gameObject.SetActive(false);
        }
    }
    public void StartRecetaClicked()
    {
        VerRecetaButtonOn();
    }
    public void VerRecetaClicked()
    {
        OnVerReceta(receta);
    }
    public void VerRecetaButtonOn()
    {
		if (!popupLeft.activeSelf)
			return;
        Events.ResetGlobos();
        globoVerReceta.gameObject.SetActive(true);
        globoReceta.SetActive(false);
    }
    public void VerRecetaButtonOff()
    {
        globoVerReceta.gameObject.SetActive(false);
        globoReceta.SetActive(false);
    }
    public void IngredienteReady()
    {
		if (!popupLeft.activeSelf)
			return;
        globoVerReceta.gameObject.SetActive(false);
        globoReceta.SetActive(true);
    }
    public bool CheckRecetaReady()
    {
        foreach (RecetaLine line in GetActualRecetaArray())
            if (!line.ready)
            {
                print(line.ingrediente + " FALSE");
                return false;
            }
        Next();
        return true;
    }
}
