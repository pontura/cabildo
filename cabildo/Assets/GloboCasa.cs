using UnityEngine;
using System.Collections;

public class GloboCasa : MonoBehaviour {
    
	void Start () {
	
	}
    public void Clicked(string id)
    {
        Events.OnGloboPopup(id);
        Vector2 pos = new Vector2(-1000, 0);
        transform.position = pos;
    }
}
