using UnityEngine;
using System.Collections;

public class GlobosManager : MonoBehaviour {

    public GloboInfo globoSimple;
    public GloboMultipleChoice globoMultipleChoice;
    public GloboFoto globoFoto;
    public GloboCasa globoCasa;
    public GloboPopup globoPopup;
    public GloboHeader globoHeader;
    public UICocina cocina;

    private Texts texts;

    void Start() {
        cocina.gameObject.SetActive(false);
        texts = Data.Instance.texts;
        Events.OnClick += OnClick;
        Events.OnGloboPopup += OnGloboPopup;
        Events.OnClickOutside += OnClickOutside;
        ResetGlobos();
    }
    void OnGloboPopup(string id)
    {
        CheckForHeaderText(id);
        switch (id)
        {
           // case "banio": banio.SetActive(true); break;
            case "cocina": cocina.gameObject.SetActive(true); break;
           // case "cuarto": cuarto.SetActive(true); break;
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
        globoSimple.gameObject.SetActive(false);
        globoMultipleChoice.gameObject.SetActive(false);
        globoFoto.gameObject.SetActive(false);
        globoCasa.gameObject.SetActive(false);
    }
    void OnClick(Vector3 pos, string id)
    {
        ResetGlobos();
        CheckForHeaderText(id);
        CheckMultipleChoice(id, pos);
        CheckSpecialGlobo(id);
    }
    void CheckForHeaderText(string id)
    {
        Texts.SimpleContent simpleContent = Data.Instance.texts.GetSimpleContentData(id);
        if (simpleContent != null)
            globoHeader.Init(simpleContent);
    }
    void CheckMultipleChoice(string id, Vector2 pos)
    {
        Texts.MultipleChoice mc = Data.Instance.texts.GetMultipleChoiceData(id);
        if (mc != null)
        {
            globoMultipleChoice.transform.position = pos;
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
