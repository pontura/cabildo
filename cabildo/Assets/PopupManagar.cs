using UnityEngine;
using System.Collections;

public class PopupManagar : MonoBehaviour {

    public GameObject banio;
    public GameObject cocina;
    public GameObject cuarto;

    public Camera cameraPopup;

	void Start () {
        Events.OnGloboPopup += OnGloboPopup;
    }
    void OnDestroy()
    {
        Events.OnGloboPopup -= OnGloboPopup;
    }    
    void OnGloboPopup(string id) {
        print("OnGloboPopup " + id);
        ResetAll();        
        switch (id)
        {
            case "banio":  banio.SetActive(true); break;
            case "cocina": cocina.SetActive(true); break;
            case "cuarto": cuarto.SetActive(true); break;
        }
        cameraPopup.enabled = true;
    }
    void ResetAll()
    {
       // cameraPopup.enabled = false;
        banio.SetActive(false);
        cocina.SetActive(false);
        cuarto.SetActive(false);
    }
}
