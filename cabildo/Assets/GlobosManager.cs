using UnityEngine;
using System.Collections;

public class GlobosManager : MonoBehaviour {

    public sides side;
    public enum sides
    {
        LEFT,
        RIGHT
    }
    
    public GloboInfo globoSimple;
    public GloboInfo globoSimpleAbajo;
    public GloboMultipleChoice globoMultipleChoice;
    public GloboFoto globoFoto;
    public GloboCasa globoCasa;
    public GloboPulperia globoPulperia;
    public GloboPopup globoPopup;
    public Globo2Popup globoPopup2;
    public GloboHeader globoHeader;
    public GloboHeader globoHeader2;
    public UICocina cocina;
    public UICuarto cuarto;
    public UIAljibe aljibe;

    public UIPulperia pulperia;
    public UIBochas bochas;
    public UIPerinola perinola;

    private Texts texts;

    void Start() {

        cocina.gameObject.SetActive(false);
        cuarto.gameObject.SetActive(false);
        aljibe.gameObject.SetActive(false);

        pulperia.gameObject.SetActive(false);
        bochas.gameObject.SetActive(false);
        perinola.gameObject.SetActive(false);

        texts = Data.Instance.texts;
        Events.OnClick += OnClick;
        Events.OnGloboPopup += OnGloboPopup;
        Events.OnGlobo2Popup += OnGlobo2Popup;
        Events.OnGloboMultipleChoice += OnGloboMultipleChoice;
        Events.OnClickOutside += OnClickOutside;
        Events.OnGloboSimple += OnGloboSimple;
        Events.OnGloboSimpleAbajo += OnGloboSimpleAbajo;
        Events.ResetGlobos += ResetGlobos;
        Events.ResetGlobos2 += ResetGlobos2;
        Events.ResetPopup += ResetPopup;
        ResetGlobos();
    }
    void OnDestroy()
    {
        Events.OnClick -= OnClick;
        Events.OnGloboPopup -= OnGloboPopup;
        Events.OnGlobo2Popup -= OnGlobo2Popup;
        Events.OnGloboMultipleChoice -= OnGloboMultipleChoice;
        Events.OnClickOutside -= OnClickOutside;
        Events.OnGloboSimple -= OnGloboSimple;
        Events.OnGloboSimpleAbajo -= OnGloboSimpleAbajo;
        Events.ResetPopup -= ResetPopup;
        Events.ResetGlobos -= ResetGlobos;
        Events.ResetGlobos2 -= ResetGlobos2;
    }
    void ResetPopup(GlobosManager.sides side)
    {
        if(side == sides.LEFT)
            globoPopup.gameObject.SetActive(false);
        if (side == sides.RIGHT)
            globoPopup2.gameObject.SetActive(false);
    }
    void OnGloboSimple(string title, Vector2 pos, string text)
    {
        GloboInfo newGloboSimple = Instantiate(globoSimple);
        newGloboSimple.transform.SetParent(this.transform);
        newGloboSimple.transform.localPosition = pos;
        newGloboSimple.Init(title, text);
    }
    void OnGloboSimpleAbajo(Vector2 pos, string text, int resetTime = 2)
    {
        GloboInfo newGloboSimpleAbajo = Instantiate(globoSimpleAbajo);
        newGloboSimpleAbajo.transform.SetParent(transform);
        newGloboSimpleAbajo.gameObject.SetActive(true);
        newGloboSimpleAbajo.transform.localPosition = pos;
        newGloboSimpleAbajo.InitAndReset(text, Data.Instance.texts.GetContent(text), resetTime);
    }
    void OnGloboPopup(string id)
    {
        CheckForHeaderText(id);
        switch (id)
        {
            case "cocina": cocina.gameObject.SetActive(true); break;
            case "cuarto": cuarto.gameObject.SetActive(true); break;
            case "aljibe": aljibe.gameObject.SetActive(true); break;
        }
        globoPopup.gameObject.SetActive(true);
    }
    void OnGlobo2Popup(string id)
    {
        CheckForHeaderText(id);
        switch (id)
        {
            case "localPulperia": pulperia.gameObject.SetActive(true); break;
            case "bochas": bochas.gameObject.SetActive(true); break;
            case "perinola": perinola.gameObject.SetActive(true); break;
        }
        globoPopup2.gameObject.SetActive(true);
    }
    void OnClickOutside(Vector3 pos)
    {
        if(pos.x>0)
        {
            ResetGlobos2();
            Events.OnHeader2Off();
            globoPopup2.gameObject.SetActive(false);
        }
        else
        {
            ResetGlobos();
            Events.OnHeaderOff();
            globoPopup.gameObject.SetActive(false);
        }
        
    }
    void ResetGlobos()
    {
        cuarto.gameObject.SetActive(false);
        aljibe.gameObject.SetActive(false);
        cocina.globoReceta.gameObject.SetActive(false);
        cocina.globoVerReceta.gameObject.SetActive(false);
        globoSimpleAbajo.gameObject.SetActive(false);
        globoMultipleChoice.gameObject.SetActive(false);
        globoFoto.gameObject.SetActive(false);
        globoCasa.gameObject.SetActive(false);
        globoPulperia.gameObject.SetActive(false);
    }
    void ResetGlobos2()
    {
        pulperia.gameObject.SetActive(false);
        bochas.gameObject.SetActive(false);
        perinola.gameObject.SetActive(false);
    }
    void OnClick(Vector3 pos, string id)
    {
        if(pos.x>0)
        {
            ResetGlobos2();
            CheckForHeaderText2(id);
        }
        else
        {
            ResetGlobos();
            CheckForHeaderText(id);
        }
       
        OnGloboMultipleChoice(pos, id);
        CheckSpecialGlobo(id);
    }
    void CheckForHeaderText(string id)
    {
        Texts.SimpleContent simpleContent = Data.Instance.texts.GetSimpleContentData(id);
        if (simpleContent != null)
            globoHeader.Init(simpleContent);
    }
    void CheckForHeaderText2(string id)
    {
        Texts.SimpleContent simpleContent = Data.Instance.texts.GetSimpleContentData(id);
        if (simpleContent != null)
            globoHeader2.Init(simpleContent);
    }
    void OnGloboMultipleChoice(Vector2 pos, string id)
    {
        Texts.MultipleChoice mc = Data.Instance.texts.GetMultipleChoiceData(id);        
        if (mc != null)
        {
            globoMultipleChoice.gameObject.SetActive(true);
            globoMultipleChoice.transform.localPosition = pos;
            globoMultipleChoice.Init(mc);
        }
    }
    void CheckSpecialGlobo(string id)
    {
        switch (id)
        {
            case "casaCheta":
                globoCasa.gameObject.SetActive(true);
                break;
            case "pulperia":
                globoPulperia.gameObject.SetActive(true);
                break;
            case "perinola":
                globoPulperia.gameObject.SetActive(true);
                break;
        }
    }


}
