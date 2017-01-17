using UnityEngine;
using System.Collections;

public class GloboPulperia : MonoBehaviour {

    void Start()
    {

    }
    public void Clicked(string id)
    {
        Events.OnGlobo2Popup(id);
        gameObject.SetActive(false);
    }
}
