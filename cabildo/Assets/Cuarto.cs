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
        print(animNAme);
        anim.Play(animNAme);
    }
    public void SetRopa(UICuarto.sexs sex, int id)
    {
        ResetRopas(sex);
        print(sex +     "  id:   " + id);
        switch (sex)
        {
            case UICuarto.sexs.MUJER:
                animMujer.Play("ropa" + id);
                if (id == 1)
                    SetRopa(mujerRopa1);
                if (id == 2)
                    SetRopa(mujerRopa2);
                if (id == 3)
                    SetRopa(mujerRopa3);
                break;
            case UICuarto.sexs.VARON:
                animVaron.Play("ropa" + id);
                if (id == 1)
                    SetRopa(varonRopa1);
                if (id == 2)
                    SetRopa(varonRopa2);
                if (id == 3)
                    SetRopa(varonRopa3);
                break;
        }
    }
    private void SetRopa(GameObject[] ropas)
    {
        print("__________" + ropas);
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
}
