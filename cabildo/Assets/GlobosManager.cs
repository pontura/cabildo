﻿using UnityEngine;
using System.Collections;

public class GlobosManager : MonoBehaviour {

    public GloboInfo globoSimple;
    public GloboMultipleChoice globoMultipleChoice;
    public GloboFoto globoFoto;
    public GloboCasa globoCasa;
    public GloboPopup globoPopup;
    public GloboHeader globoHeader;

    private Texts texts;
    private Vector2 globoCasa_pos;

    void Start() {
        globoCasa_pos = globoCasa.transform.position;
        texts = Data.Instance.texts;
        Events.OnGloboDialogo += OnGloboDialogo;
        Events.OnGloboPopup += OnGloboPopup;
        Events.OnClickOutside += OnClickOutside;
        ResetGlobos();
    }
    void OnGloboPopup(string id)
    {
        globoPopup.gameObject.SetActive(true);
    }
    void OnClickOutside()
    {
        ResetGlobos();
    }
    void ResetGlobos()
    {
        Vector2 pos = new Vector2(-1000, 0);
        globoSimple.transform.position = pos;
        globoMultipleChoice.transform.position = pos;
        globoFoto.transform.position = pos;
        globoCasa.transform.position = pos;
        globoPopup.gameObject.SetActive(false);
    }
    void OnGloboDialogo(Vector3 pos, string id)
    {
        ResetGlobos();
        texts.GetSimpleContentData(id);

        Texts.SimpleContent simpleContent = Data.Instance.texts.GetSimpleContentData(id);
        if(simpleContent != null)
            globoHeader.Init(simpleContent);

        Texts.MultipleChoice mc = Data.Instance.texts.GetMultipleChoiceData(id);
        if (mc != null)
        {
            globoMultipleChoice.transform.position = pos;
            globoMultipleChoice.Init(mc);
        }

        switch (id)
        {
            case "casaCheta":
                globoCasa.transform.position = globoCasa_pos;
                break;
        }

        print("OnGloboDialogo pos: " + pos + "    id: " + id + " type: " + id);

    }

}
