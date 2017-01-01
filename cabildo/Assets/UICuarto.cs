using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UICuarto : MonoBehaviour {

    public sexs selectedSex;

    public GameObject buttonBania;
    public GameObject buttonViste;

    public Cuarto cuarto;

    public GameObject boy;
    public GameObject girl;

    public GameObject hint_Girl;
    public GameObject hint_Boy;

    public GameObject baniaGirl;
    public GameObject baniaBoy;

    public enum sexs
    {
        VARON,
        MUJER
    }
    public actions action;
    public enum actions
    {
        NONE,
        VESTIR,
        BANIAR
    }
    void OnEnable () {
        Reset();
        ShowButtons(false);
    }
    public void SaleBanio(int id)
    {
        if(id == 1)
        {
            if (!baniaGirl.activeSelf) return;
            girl.SetActive(true); baniaGirl.SetActive(false);
        } else
        {
            if (!baniaBoy.activeSelf) return;
            boy.SetActive(true); baniaBoy.SetActive(false);
        }
    }
    public void RopaSelected(int id)
    {
        if (!cuarto.armarioOpened) return;
        cuarto.SetRopa(selectedSex, id);
    }
    public void SelectBoy()
    {
        ArmarioClicked();
        if (selectedSex == sexs.VARON && baniaBoy.activeSelf) return; 

        selectedSex = sexs.VARON;
        hint_Boy.SetActive(false);
        UpdateUI();
    }
    public void SelectGirl()
    {
        ArmarioClicked();
        if (selectedSex == sexs.MUJER && baniaGirl.activeSelf) return;

        selectedSex = sexs.MUJER;
        hint_Girl.SetActive(false);
        UpdateUI();
    }
    public void Vestir()
    {
        action = actions.VESTIR;

        switch (selectedSex)
        {
            case sexs.MUJER:
                cuarto.SetArmario(sexs.MUJER, true);
                break;
            case sexs.VARON:
                cuarto.SetArmario(sexs.VARON, true);
                break;
        }
        UpdateUI();
        print("Vestir " + selectedSex);
    }
    public void Baniar()
    {
        action = actions.BANIAR;

        switch(selectedSex)
        {
            case sexs.MUJER: girl.SetActive(false); baniaGirl.SetActive(true); break;
            case sexs.VARON: boy.SetActive(false); baniaBoy.SetActive(true); break;
        }
        UpdateUI();
    }
    void Reset()
    {
        action = actions.NONE;
        hint_Girl.SetActive(true);
        hint_Boy.SetActive(true);

        boy.SetActive(true);
        girl.SetActive(true);
        

        baniaGirl.SetActive(false);
        baniaBoy.SetActive(false);
    }
    public void ArmarioClicked()
    {
        if (!cuarto.armarioOpened) return;

        switch (selectedSex)
        {
            case sexs.MUJER:
                cuarto.SetArmario(sexs.MUJER, false);
                break;
            case sexs.VARON:
                cuarto.SetArmario(sexs.VARON, false);
                break;
        }
    }
    void UpdateUI()
    {
        switch (selectedSex)
        {
            case sexs.MUJER:
                if (baniaGirl.activeSelf || cuarto.armarioOpened)
                    ShowButtons(false);
                else
                    ShowButtons(true);
                break;
            case sexs.VARON:
                if (baniaBoy.activeSelf || cuarto.armarioOpened)
                    ShowButtons(false);
                else
                    ShowButtons(true);
                break;
        }
    }
    void ShowButtons(bool si)
    {
        if (!si)
        {
            buttonBania.SetActive(false);
            buttonViste.SetActive(false);
        }
        else
        {
            buttonBania.SetActive(true);
            buttonViste.SetActive(true);
        }
    }
}
