using UnityEngine;
using System.Collections;

public class GlobosManager : MonoBehaviour {

    public GloboDialogo globoDialogo;
    public GloboFoto globoFoto;
    public GloboInfo globoInfo;

    void Start() {
        Events.OnGloboDialogo += OnGloboDialogo;
    }
    void OnGloboDialogo(Vector3 pos, string text)
    {
        globoDialogo.transform.position = pos;
        globoDialogo.Init(text);
    }

}
