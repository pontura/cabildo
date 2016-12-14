using UnityEngine;
using System.Collections;

public class GloboPopup : MonoBehaviour {
    
	void Start () {
	
	}
    public void Close()
    {
        gameObject.SetActive(false);
        Events.OnHeaderOff();
    }
}
