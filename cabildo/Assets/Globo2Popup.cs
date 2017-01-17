using UnityEngine;
using System.Collections;

public class Globo2Popup : MonoBehaviour {

    void Start()
    {

    }
    public void Close()
    {
        gameObject.SetActive(false);
        Events.OnHeader2Off();
        Events.ResetGlobos2();
    }
}
