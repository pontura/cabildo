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
    public GloboPopup globoPopup;
    public GloboHeader globoHeader;
    public UICocina cocina;
    public UICuarto cuarto;

    private Texts texts;

    void Start() {
        cocina.gameObject.SetActive(false);
        cuarto.gameObject.SetActive(false);
        texts = Data.Instance.texts;
        Events.OnClick += OnClick;
        Events.OnGloboPopup += OnGloboPopup;
        Events.OnGloboMultipleChoice += OnGloboMultipleChoice;
        Events.OnClickOutside += OnClickOutside;
        Events.OnGloboSimple += OnGloboSimple;
        Events.OnGloboSimpleAbajo += OnGloboSimpleAbajo;
        Events.OnGloboSimpleAbajo += OnGloboSimpleAbajo;
        Events.ResetGlobos += ResetGlobos;
        Events.ResetPopup += ResetPopup;
        ResetGlobos();
    }
    void OnDestroy()
    {
        Events.OnClick -= OnClick;
        Events.OnGloboPopup -= OnGloboPopup;
        Events.OnGloboMultipleChoice -= OnGloboMultipleChoice;
        Events.OnClickOutside -= OnClickOutside;
        Events.OnGloboSimple -= OnGloboSimple;
        Events.OnGloboSimpleAbajo -= OnGloboSimpleAbajo;
        Events.ResetPopup -= ResetPopup;
        Events.ResetGlobos -= ResetGlobos;
    }
    void ResetPopup(GlobosManager.sides side)
    {
        if(side == sides.LEFT)
            globoPopup.gameObject.SetActive(false);
    }
    void OnGloboSimple(Vector2 pos, string text)
    {
        ResetGlobos();
        globoSimple.gameObject.SetActive(true);
        globoSimple.transform.localPosition = pos;
        globoSimple.Init(Data.Instance.texts.GetContent(text));
    }
    void OnGloboSimpleAbajo(Vector2 pos, string text)
    {
        ResetGlobos();
        globoSimpleAbajo.gameObject.SetActive(true);
        globoSimpleAbajo.transform.localPosition = pos;
        globoSimpleAbajo.Init(Data.Instance.texts.GetContent(text));
    }
    void OnGloboPopup(string id)
    {
        CheckForHeaderText(id);
        switch (id)
        {
           // case "banio": banio.SetActive(true); break;
            case "cocina": cocina.gameObject.SetActive(true); break;
            case "cuarto": cuarto.gameObject.SetActive(true); break;
        }
        globoPopup.gameObject.SetActive(true);
    }
    void OnClickOutside()
    {
        ResetGlobos();
        Events.OnHeaderOff();
        globoPopup.gameObject.SetActive(false);
    }
    void ResetGlobos()
    {
        cuarto.gameObject.SetActive(false);
        cocina.globoReceta.gameObject.SetActive(false);
        cocina.globoVerReceta.gameObject.SetActive(false);
        globoSimpleAbajo.gameObject.SetActive(false);
        globoSimple.gameObject.SetActive(false);
        globoMultipleChoice.gameObject.SetActive(false);
        globoFoto.gameObject.SetActive(false);
        globoCasa.gameObject.SetActive(false);
    }
    void OnClick(Vector3 pos, string id)
    {
        ResetGlobos();
        CheckForHeaderText(id);
        OnGloboMultipleChoice(pos, id);
        CheckSpecialGlobo(id);
    }
    void CheckForHeaderText(string id)
    {
        Texts.SimpleContent simpleContent = Data.Instance.texts.GetSimpleContentData(id);
        if (simpleContent != null)
            globoHeader.Init(simpleContent);
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
        }
    }


}
