using UnityEngine;
using System.Collections;

public class Caminante : MonoBehaviour {

    public directions direction;
    public enum directions
    {
        LEFT_RIGHT,
        RIGHT_LEFT
    }
    public int time_to_cross;
    public int delay_to_appear;

    private Character character;

    void Start()
    {
        character = GetComponent<Character>();
        Loop();
        Events.OnClick += OnClick;
    }
    void OnDestroy()
    {
        Loop();
        Events.OnClick -= OnClick;
    }
    private bool paused;
    void OnClick(Vector3 pos, string title)
    {
        if (title != gameObject.name) return;
        if (paused)
        {
            iTween.Resume();
            character.Walk();
            paused = false;
        } else 
        {
            character.Idle();
            paused = true;
            iTween.Pause(gameObject);
        }
    }
    void Loop()
    {
        print("Loop");
        Invoke("StartAnim", delay_to_appear);
    }
    void StartAnim()
    {
        character.Walk();
        Vector3 pos = transform.position;

        if (direction == directions.LEFT_RIGHT)
            pos.x = -10;
        else
            pos.x = 10;
        transform.position = pos;

        float newPos = (pos.x * -1) * 2;
        if (transform.localScale.x < 0) newPos *= -1;

        iTween.MoveBy(gameObject, iTween.Hash(
            "x", newPos,
            "time", time_to_cross,
            "oncomplete", "Loop",
            "easetype", "linear"
        ));
    }
}
