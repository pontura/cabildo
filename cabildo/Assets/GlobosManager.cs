using UnityEngine;
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
        Events.OnClick += OnClick;
        Events.OnGloboPopup += OnGloboPopup;
        Events.OnClickOutside += OnClickOutside;
        ResetGlobos();
    }
    void OnGloboPopup(string id)
    {
        CheckForHeaderText(id);
        globoPopup.gameObject.SetActive(true);
    }
    void OnClickOutside()
    {
        ResetGlobos();
        Events.OnHeaderOff();
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
                globoCasa.transform.position = globoCasa_pos;
                break;
        }
    }


}
