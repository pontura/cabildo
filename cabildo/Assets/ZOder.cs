using UnityEngine;
using System.Collections;

public class ZOder : MonoBehaviour {

    public layers layer;
    public enum layers
    {
        LAYER_1,
        LAYER_5,
        LAYER_10
    }

	void Start () {
        foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>())
        {
            sr.sortingLayerName = layer.ToString();
        }
	}
}
