using UnityEngine;
using System.Collections;

public class PerinolaMoneda : MonoBehaviour {

    public states state;
    public Perinola perinola;
    private Vector3 newPos;
    public float speed;

    public enum states
    {
        POZO,
        PLAYER_1,
        PLAYER_2
    }
    public void Init(Perinola perinola, states newState)
    {
        this.perinola = perinola;
        state = newState;
        newPos = perinola.GetZone(state);
        transform.position = newPos;
    }
    public void ChangeState(states newState)
    {
        state = newState;
        newPos = perinola.GetZone(state);
	}
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, newPos, speed);
    }
}
