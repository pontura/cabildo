using UnityEngine;
using System.Collections;

public class Popup2Manager : MonoBehaviour {

    public GameObject localPulperia;
    public GameObject bochas;
    public GameObject perinola;

    public Camera cameraPopup;

    void Start()
    {
        Events.OnGlobo2Popup += OnGlobo2Popup;
    }
    void OnDestroy()
    {
        Events.OnGlobo2Popup += OnGlobo2Popup;
    }
    void OnGlobo2Popup(string id)
    {
        ResetAll();
        switch (id)
        {
            case "localPulperia": localPulperia.SetActive(true); break;
            case "bochas": bochas.SetActive(true); break;
            case "perinola": perinola.SetActive(true); break;
        }
        cameraPopup.enabled = true;
    }
    void ResetAll()
    {
        localPulperia.SetActive(false);
        bochas.SetActive(false);
        perinola.SetActive(false);
    }
}
