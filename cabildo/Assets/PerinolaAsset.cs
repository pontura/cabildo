using UnityEngine;
using System.Collections;

public class PerinolaAsset : MonoBehaviour {

    public Perinola perinola;
    public results result;
    public enum results
    {
        TOMA_TODO,
        TOMA1,
        TOMA2,
        PON1,
        PON2,
        TODOS_PONEN
    }
    public GameObject perinola_up;
    public GameObject perinola_down;

    public GameObject TOMA_TODO_GO;
    public GameObject TOMA1_GO;
    public GameObject TOMA2_GO;
    public GameObject PON1_GO;
    public GameObject PON2_GO;
    public GameObject TODOS_PONEN_GO;

    void OnEnable()
    {
        ResetAll();
        perinola_down.SetActive(true);
        SetResult();
    }
    public void Init()
    {
        ResetAll();
        perinola_up.SetActive(true);
    }
    public void ChangeAsset()
    {
        ResetAll();
        perinola_down.SetActive(true);
        SetResult();
    }
    void SetResult()
    {
        int rand = Random.Range(1, 7);
        switch(rand)
        {
            case 1: result = results.TOMA_TODO;         TOMA_TODO_GO.SetActive(true); break;
            case 2: result = results.TOMA1;             TOMA1_GO.SetActive(true); break;
            case 3: result = results.TOMA2;             TOMA2_GO.SetActive(true); break;
            case 4: result = results.PON1;              PON1_GO.SetActive(true); break;
            case 5: result = results.PON2;              PON2_GO.SetActive(true); break;
            case 6: result = results.TODOS_PONEN;       TODOS_PONEN_GO.SetActive(true); break;
        }
    }
    void ResetAll()
    {
        perinola_up.SetActive(false);
        perinola_down.SetActive(false);
        TOMA_TODO_GO.SetActive(false);
        TOMA1_GO.SetActive(false);
        TOMA2_GO.SetActive(false);
        PON1_GO.SetActive(false);
        PON2_GO.SetActive(false);
        TODOS_PONEN_GO.SetActive(false);
    }
}
