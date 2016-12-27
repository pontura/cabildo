using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UICuarto : MonoBehaviour {

    public sexs selectedSex;

    public Text vestirText;
    public Text baniarText;

    public GameObject hint_Girl;
    public GameObject hint_Boy;

    public GameObject baniaGirl;
    public GameObject baniaBoy;

    public GameObject ropaBoy;
    public GameObject ropaGirl;

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
    void Start () {
        Reset();
    }
	public void SelectBoy()
    {
        selectedSex = sexs.VARON;
        hint_Girl.SetActive(true);
        hint_Boy.SetActive(false);
    }
    public void SelectGirl()
    {
        selectedSex = sexs.MUJER;
        hint_Girl.SetActive(false);
        hint_Boy.SetActive(true);
    }
    public void Vestir()
    {
        Reset();
        action = actions.VESTIR;
        vestirText.text = "¡Listo!";
        switch (selectedSex)
        {
            case sexs.MUJER: ropaGirl.SetActive(true); break;
            case sexs.VARON: ropaBoy.SetActive(true); break;
        }
    }
    public void Baniar()
    {
        Reset();
        action = actions.BANIAR;
        baniarText.text = "¡Listo!";

        switch(selectedSex)
        {
            case sexs.MUJER: baniaGirl.SetActive(true); break;
            case sexs.VARON: baniaBoy.SetActive(true); break;
        }
    }
    void ResetTexts()
    {
        action = actions.NONE;
        vestirText.text = "Vestir";
        baniarText.text = "Bañar";
    }
    void Reset()
    {
        ResetTexts();
        hint_Girl.SetActive(true);
        hint_Boy.SetActive(true);

        ropaGirl.SetActive(false);
        ropaBoy.SetActive(false);

        baniaGirl.SetActive(false);
        baniaBoy.SetActive(false);
    }
}
