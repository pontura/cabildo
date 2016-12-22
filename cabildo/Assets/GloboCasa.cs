using UnityEngine;
using System.Collections;

public class GloboCasa : MonoBehaviour {
    
	void Start () {
	
	}
    public void Clicked(string id)
    {
        Events.OnGloboPopup(id);
        gameObject.SetActive(false);
    }
}
