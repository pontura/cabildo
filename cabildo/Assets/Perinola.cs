using UnityEngine;
using System.Collections;

public class Perinola : MonoBehaviour {

    public GameObject perinola;
    private float defaultSpeed = 20;
    private float rotationSpeed;
    public states state;
    public enum states
    {
        IDLE,
        ROTATE_1,
        ROTATE_2,
        DONE
    }
    public Transform zona_pozo;
    public Transform zona_player_1;
    public Transform zona_player_2;

    private int speed = 3;
    public PerinolaAsset asset;
    public PerinolaMonedasManager manager;
    public UIPerinola ui;

    public void OnEnable()
    {
        manager.Init();
    }
    void OnDisable()
    {
        CancelInvoke();
        Reset();
    }
    void Reset()
    {
        state = states.IDLE;
        perinola.transform.localPosition = new Vector3(-3.21f, 2.11f, 0);
       // asset.Init();
    }
    public void OnPerinola()
    {
        Reset();
        asset.Init();
        state = states.ROTATE_1;
        rotationSpeed = defaultSpeed;
		Events.OnSFX(Data.Instance.sFXManager.perinola);
    }

    void Update()
    {
        Vector3 rot = perinola.transform.localEulerAngles;
        Vector3 pos = perinola.transform.localPosition;
        if (state == states.ROTATE_1)
        {
            rotationSpeed -= Time.deltaTime * speed;
            if (rotationSpeed < 5f)
            {
                asset.ChangeAsset();
                state = states.ROTATE_2;
            }            
            rot.z += rotationSpeed;
            perinola.transform.localEulerAngles = rot;
            pos.x += ((float)Random.Range(0, 10) - 5)/200;
            pos.y += ((float)Random.Range(0, 10) - 5)/200;
            perinola.transform.localPosition = Vector3.Lerp(perinola.transform.localPosition, pos, 0.5f);
        }
        else if (state == states.ROTATE_2)
        {
            rotationSpeed -= Time.deltaTime * speed;
            rot.z += rotationSpeed;
            perinola.transform.localEulerAngles = rot;
            if (rotationSpeed < 1)
                RotationReady();
        }
    }
    void RotationReady()
    {
        state = states.DONE;
        //perinola.transform.localEulerAngles = Vector3.zero;
        manager.SetResult(asset.result);
		int winner = manager.GetWinner ();
		if (winner == 0)
			ui.Restart ();
		else
			ui.Gana (winner);
    }
    private float Rand_X = 100;
    private float Rand_Y = 100;

    public Vector3 GetZone(PerinolaMoneda.states state)
    {
        Vector3 zone;
        switch(state)
        {
            case PerinolaMoneda.states.PLAYER_1:
                zone = zona_player_1.transform.position;
                break;
            case PerinolaMoneda.states.PLAYER_2:
                zone = zona_player_2.transform.position;
                break;
            default:
                zone = zona_pozo.transform.position;
                break;
        }
        float r_x = (Random.Range(0, Rand_X) / Rand_X ) - 0.5f;
        float r_y = (Random.Range(0, Rand_Y) / Rand_Y) - 0.5f;

        if (state == PerinolaMoneda.states.POZO)
        {
            r_x *= 3;
            r_y *= 0.7f;
        }
        else
        {
            r_x *= 0.8f;
            r_y *= 1.5f;
        }

        zone.x += r_x;
        zone.y += r_y;
        
        return zone;
    }
    
}
