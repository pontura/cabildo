using UnityEngine;
using System.Collections;

public class MapBigButton : MonoBehaviour {

    public string txtID;

	public void Clicked()
    {
        if(txtID != "")
            Events.SetSignalText(txtID);

    }
}
