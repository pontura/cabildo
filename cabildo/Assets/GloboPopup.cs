using UnityEngine;
using System.Collections;

public class GloboPopup : MonoBehaviour {
    
	void OnEnable () {
		Events.ConversationKill ("negrito");
	}
    public void Close()
    {
        gameObject.SetActive(false);
        Events.OnHeaderOff();
        Events.ResetGlobos();
    }
}
