using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class UICocina : MonoBehaviour {

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

    void OnEnable()
    {
        Reset();
        receta = recetas.PUCHERO;
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
                if (GetIngredienteInReceta(receta_locro, ingrediente).ready) return true;
                break;
            case recetas.CARBONADA:
                if (GetIngredienteInReceta(receta_carbonada, ingrediente).ready) return true;
                break;
        }
        return false;
    }
    public bool IsInTheReceta(Cocina.minigames ingrediente)
    {
        return true;
    }
    void Reset()
    {
        locro.SetActive(false);
        carbonada.SetActive(false);
        puchero.SetActive(false);
    }
    public void StartRecetaClicked()
    {
        globoVerReceta.gameObject.SetActive(true);
        globoReceta.SetActive(false);
    }
    public void VerRecetaClicked()
    {
        OnVerReceta(receta);
    }
}
