using UnityEngine;
using System.Collections;

public class Iglesia : MonoBehaviour {

    public Character Hombre1;
    public Character Mujer1;

    public Character Hombre2;
    public Character Mujer2;
    public Character Hombre3;
	public Character Sirviente;

    private Animation anim;

    public states state;
    public enum states
    {
        IDLE,
        ACTIVE
    }

    void Start () {
        anim = GetComponent<Animation>();
        Events.OnClick += OnClick;
    }	
    void OnClick(Vector3 pos, string title)
    {
        if (state == states.IDLE && title == "campana")
            SetActive();
    }
    void SetActive()
    {
		Events.OnSFX (Data.Instance.sFXManager.bell);
        state = states.ACTIVE;
        anim.Play("active");
        Invoke("Idle", 12);
    }
    void Idle()
    {
        state = states.IDLE;
        anim.Play("idle");
        
        Hombre1.Restart();
        Hombre2.Restart();
        Hombre3.Restart();
        Mujer1.Restart();
        Mujer2.Restart();
		Sirviente.Restart ();
    }
    public void Walk_Ricos()
    {
        Hombre1.Walk();
        Hombre2.Walk();
        Hombre3.Walk();
        Mujer1.Walk();
        Mujer2.Walk();
		Sirviente.Walk();
    }
}
