using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BochasGame : MonoBehaviour {

    public Animator[] team1;
    public Animator[] team2;
    public List<GameObject> bochas;

    public GameObject bochin;

    public GameObject bocha;
    public Transform _target;
    public Material mat1;
    public Material mat2;
    public int id = 0;
    private GameObject newBocha;
    public Vector3 bochinPos;

    void Start () {
		bochin.transform.localPosition = bochinPos;
		bochin.GetComponent<Rigidbody>().velocity = Vector3.zero;

		Events.OnMinigameBochasReady += OnMinigameBochasReady;
	}
	void OnMinigameBochasReady()
	{    

        id = 0;
        foreach (GameObject bocha in bochas)
            Destroy(bocha);

        bochas.Clear();
        foreach (Animator anim in team1)
            anim.Play("idle");
        foreach (Animator anim in team2)
            anim.Play("idle");
    }
    public void NewTurn()
    {
        print("NewTurn");
        newBocha = Instantiate(bocha);
        if (id == 0)
            newBocha.GetComponent<MeshRenderer>().material = mat1;
        else
            newBocha.GetComponent<MeshRenderer>().material = mat2;

        newBocha.GetComponent<BochaBall>().id = id;
		newBocha.transform.SetParent(_target);
        newBocha.transform.localPosition = Vector3.zero;

        bochas.Add(newBocha);
    }
    public void Throw(float angle, int speed)
    {
		Events.OnSFX (Data.Instance.sFXManager.woodPop);
        newBocha.transform.localEulerAngles = new Vector3(0, angle, 0);
        Vector3 force = newBocha.transform.forward * speed;
        newBocha.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
        id++;
        if (id > 1) id = 0;
    }
    public void Ready()
    {
        float minDistance = 1000;
        int winnerID = 0;
		print ("Ready ");
        foreach(GameObject bocha in  bochas)
        {
            float newDistance = Vector3.Distance(bocha.transform.position, bochin.transform.position);
            print(bocha.GetComponent<BochaBall>().id + " +++++ " + newDistance);
            if(newDistance<minDistance)
            {
                minDistance = newDistance;
                winnerID = bocha.GetComponent<BochaBall>().id;
            }
        }
        if (winnerID == 0)
            foreach (Animator anim in team1)
                anim.Play("applause");
        else
            foreach (Animator anim in team2)
                anim.Play("applause");
		
		Events.OnSFX(Data.Instance.sFXManager.applause);
    }
}
