using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIBochas : MonoBehaviour {

    public Text field;
    public Image SpeedImage;
    public GameObject playBtn;
    public BochasGame game;
    public Vector3 angle;
    public int speed;
    public GameObject shooter;
    public states state;
    private float rotationSpeed = 0.5f;
    private float MAX_ROT = 30;
    private float fillAmount;
    private float fillAmountSpeed = 2;
    private int tiros;
    
    public GameObject bolas_rojas;
    public GameObject bolas_verdes;

    public enum states
    {
        CLOSED,
        AIMING,
        SPEED,
        SHOOTING,
        READY
    }
    void OnDisable()
    {
        state = states.CLOSED;
        CancelInvoke();
    }
    void OnEnable()
    {
        state = states.AIMING;

        foreach (Image im in bolas_rojas.GetComponentsInChildren<Image>())
            im.enabled = true;
        foreach (Image im in bolas_verdes.GetComponentsInChildren<Image>())
            im.enabled = true;

        tiros = 0;
        NewTurn();        
    }
	public void ClickPlay()
    {
        if (state == states.AIMING)
        {
            field.text = "Fuerza";
            state = states.SPEED;
            fillAmount = 0;
            SpeedImage.enabled = true;
        } else if (state == states.SPEED)
        {
            playBtn.SetActive(false);
            int speedReal = (int)(speed * (12 * fillAmount));
            game.Throw(-rotation_z, speedReal);
            state = states.SHOOTING;
            Invoke("NewTurn", 4);
            shooter.SetActive(false);
        }
    }
    void NewTurn()
    {
        if (state == states.CLOSED)
            return;
        state = states.AIMING;
        tiros++;
        if(tiros > 10)
        {
            Ready();
            return;
        }
        RemoveBall(game.id);
        
        shooter.SetActive(true);
        game.NewTurn();
        playBtn.SetActive(true);
        field.text = "Apunta";
        SpeedImage.enabled = false;
        state = states.AIMING;
    }
    void RemoveBall(int teamID)
    {
        if (teamID == 0)
        {
            foreach (Image im in bolas_rojas.GetComponentsInChildren<Image>())
            {
                if (im.enabled == true)
                {
                    im.enabled = false;
                    return;
                }
            }
        }
        else
        {
            foreach (Image im in bolas_verdes.GetComponentsInChildren<Image>())
            {
                if (im.enabled == true)
                {
                    im.enabled = false;
                    return;
                }
            }
        }
    }
    void Ready()
    {
        state = states.READY;
        game.Ready();
    }
    void Update()
    {
        if (state == states.AIMING)
            Aim();
        else if (state == states.SPEED)
            SetSpeed();
    }

    public bool right = true;
    public float rotation_z;
    void Aim()
    {
        
        Vector3 rot = shooter.transform.localEulerAngles;
        rotation_z = 180 + rot.z;

        if (right)
            rotation_z += rotationSpeed;
        else
            rotation_z -= rotationSpeed;

        if (rot.z> 180+MAX_ROT && right)
            right = false;
        else if (rot.z < 180 -MAX_ROT && !right)
            right = true;

        rot.z = rotation_z - 180;

        shooter.transform.localEulerAngles = rot;
    }

    bool crece = true;
    void SetSpeed()
    {
        if(crece)
            fillAmount += fillAmountSpeed * Time.deltaTime;
        else
            fillAmount -= fillAmountSpeed * Time.deltaTime;

        if (crece && fillAmount > 0.95)
            crece = false;
        if (!crece && fillAmount < 0.1)
            crece = true;
        SpeedImage.fillAmount = fillAmount;
    }
}
