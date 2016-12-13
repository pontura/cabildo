using UnityEngine;
using System.Collections;

public class GlobosManager : MonoBehaviour {

    public GloboInfo globoSimple;
    public GloboMultipleChoice globoMultipleChoice;
    public GloboFoto globoFoto;
    public GloboCasa globoCasa;

    private Texts texts;
    private Vector2 globoCasa_pos;

    void Start() {
        globoCasa_pos = globoCasa.transform.position;
        texts = Data.Instance.texts;
        Events.OnGloboDialogo += OnGloboDialogo;
        Events.OnClickOutside += OnClickOutside;
        ResetGlobos();
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
    }
    void OnGloboDialogo(Vector3 pos, string text)
    {
        ResetGlobos();
        Texts.types type = texts.GetTypeOfContent(text);
        switch(text)
        {
            case "casaCheta":
                globoCasa.transform.position = globoCasa_pos;
                break;
        }
        switch (type)
        {
            //case Texts.types.SIMPLE:
            //    globoSimple.transform.position = pos;
            //    globoSimple.Init(text);
            //    break;
            case Texts.types.MULTIPLECHOICE:
                globoMultipleChoice.transform.position = pos;
                globoMultipleChoice.Init(text);
                break;
        }
        print("OnGloboDialogo pos: " + pos + "    text: " + text + " type: " + type);

    }

}
