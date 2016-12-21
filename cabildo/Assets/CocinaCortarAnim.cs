using UnityEngine;
using System.Collections;

public class CocinaCortarAnim : MonoBehaviour {

    private Animator anim;

	void Start () {
        anim = GetComponent<Animator>();
    }
    public void Cut()
    {
        anim.Play("corteZanahoria");
    }
    public void PauseAnim()
    {
        anim.Stop();
    }
}
