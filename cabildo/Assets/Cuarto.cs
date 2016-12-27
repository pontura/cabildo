using UnityEngine;
using System.Collections;

public class Cuarto : MonoBehaviour {

    public Animator anim;
    public bool armarioOpened;


    void OnEnable () {
        armarioOpened = false;
    }
	public void SetArmario(UICuarto.sexs sex, bool open)
    {
        string animNAme = "";
        switch(open)
        {
            case true: animNAme = "Open"; armarioOpened = true; break;
            default: animNAme = "Close"; armarioOpened = false; break;
        }
        switch(sex)
        {
            case UICuarto.sexs.MUJER: animNAme = "armario" + "Mujer" + animNAme; break;
            case UICuarto.sexs.VARON: animNAme = "armario" + "Hombre" + animNAme; break;
        }
        print(animNAme);
        anim.Play(animNAme);
    }
}
