using UnityEngine;
using System.Collections;

public class Cuarto : MonoBehaviour
{

    public Animator anim;
    public bool armarioOpened;

    public Animator animVaron;
    public Animator animMujer;

    public GameObject[] mujerRopa1;
    public GameObject[] mujerRopa2;
    public GameObject[] mujerRopa3;

    public GameObject[] varonRopa1;
    public GameObject[] varonRopa2;
    public GameObject[] varonRopa3;

	public GameObject mujerSaleBanio;
	public GameObject hombreSaleBanio;

	public Transform baniaTextos;
	public Transform hombreTexto;
	public Transform mujerTexto;

    void OnEnable()
    {
        armarioOpened = false;
    }
    public void SetArmario(UICuarto.sexs sex, bool open)
    {
        string animNAme = "";
        switch (open)
        {
            case true: animNAme = "Open"; armarioOpened = true; break;
            default: animNAme = "Close"; armarioOpened = false; break;
        }
        switch (sex)
        {
            case UICuarto.sexs.MUJER: animNAme = "armario" + "Mujer" + animNAme; break;
            case UICuarto.sexs.VARON: animNAme = "armario" + "Hombre" + animNAme; break;
        }
        anim.Play(animNAme);
    }
    public void SetRopa(UICuarto.sexs sex, int id)
    {
		Vector2 mujerPos = new Vector2(-550,-380);
		Vector2 hombrePos = new Vector2(-400,-380);
        ResetRopas(sex);
        switch (sex)
        {
		case UICuarto.sexs.MUJER:
			animMujer.Play ("ropa" + id);
			if (id == 1) {
				SetRopa (mujerRopa1);
				Events.OnGloboSimpleAbajo(mujerPos, "traje-1-mujer", 3);
			}
			if (id == 2) {
				SetRopa (mujerRopa2);
				Events.OnGloboSimpleAbajo(mujerPos, "traje-2-mujer", 3);
			}
			if (id == 3) {
				SetRopa (mujerRopa3);
				Events.OnGloboSimpleAbajo(mujerPos, "traje-3-mujer", 3);
			}
                break;
		case UICuarto.sexs.VARON:
			animVaron.Play ("ropa" + id);
			if (id == 1) {
				SetRopa (varonRopa1);
				Events.OnGloboSimpleAbajo(hombrePos, "traje-1-hombre", 3);
			}
			if (id == 2) {
				SetRopa (varonRopa2);
				Events.OnGloboSimpleAbajo(hombrePos, "traje-2-hombre", 3);
			}
			if (id == 3) {
				SetRopa (varonRopa3);
				Events.OnGloboSimpleAbajo(hombrePos, "traje-3-hombre", 3);
			}
                break;
        }
    }
    private void SetRopa(GameObject[] ropas)
    {
        foreach (GameObject go in ropas)
            go.SetActive(true);
    }
    void ResetRopas(UICuarto.sexs sex)
    {
        switch (sex)
        {
            case UICuarto.sexs.MUJER:
                foreach (GameObject go in mujerRopa1)
                    go.SetActive(false);
                foreach (GameObject go in mujerRopa2)
                    go.SetActive(false);
                foreach (GameObject go in mujerRopa3)
                    go.SetActive(false);
                break;
            case UICuarto.sexs.VARON:
                foreach (GameObject go in varonRopa1)
                    go.SetActive(false);
                foreach (GameObject go in varonRopa2)
                    go.SetActive(false);
                foreach (GameObject go in varonRopa3)
                    go.SetActive(false);
                break;
        }
    }
	public void EntraBanio(UICuarto.sexs sex)
	{
		if (sex == UICuarto.sexs.MUJER) {
			animMujer.Play ("bañoSplash");
			Events.OnGloboSimpleAbajo(new Vector2(-620, -440), "banio-mujer", 4);
		} else {			
			Events.OnGloboSimpleAbajo(new Vector2(-750, -420), "banio-hombre", 5);
			animVaron.Play ("bañoSplash");
		}
	}
	public void SaleBanio(UICuarto.sexs sex)
	{
		if (sex == UICuarto.sexs.MUJER)
			mujerSaleBanio.SetActive (true);
		else
			hombreSaleBanio.SetActive (true);
		Invoke ("ResetAnims", 1);
	}
	void ResetAnims()
	{
		mujerSaleBanio.SetActive (false);
		hombreSaleBanio.SetActive (false);
	}
}
