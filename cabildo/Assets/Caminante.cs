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

        Events.OnClick += OnClick;
		Events.ConversationKill += ConversationKill;

		if (time_to_cross == 0)
			return;
		Loop();
    }
    void OnDestroy()
    {
        Loop();
        Events.OnClick -= OnClick;
		Events.ConversationKill -= ConversationKill;
    }
    private bool paused;
    void OnClick(Vector3 pos, string title)
    {

		if (paused || title != gameObject.name) return;

//        if (paused)
//        {
//			iTween.Resume(gameObject);
//            character.Walk();
//            paused = false;
//        } else 
//        {
            character.Idle();
            paused = true;
			iTween.Pause(gameObject);
			Vector3 pos3 = Input.mousePosition;
			pos3.x -= Screen.width / 2;
			pos3.y -= Screen.height / 2;
			string text = Data.Instance.conversaciones.GetSimpleText(title);
			Events.OnGloboSimpleTimeOut (title, new Vector2(pos3.x-10, pos3.y+50), text, 2);
//        }
    }
	void ConversationKill(string title)
	{
		if (title != gameObject.name) return;
		paused = false;
		if (time_to_cross == 0)
			return;
		iTween.Resume(gameObject);
		character.Walk();

	}
    void Loop()
    {
        Invoke("StartAnim", delay_to_appear);
    }
    void StartAnim()
    {
        character.Walk();
        Vector3 pos = transform.position;

		float newPos;// = (pos.x * -1) * 2;


		if (direction == directions.LEFT_RIGHT) {
			pos.x = -10;
			newPos = 10;
		} else {
			pos.x = 10;
			newPos = -10;
		}
        transform.position = pos;       

        iTween.MoveBy(gameObject, iTween.Hash(
            "x", newPos*2,
            "time", time_to_cross,
            "oncomplete", "Loop",
            "easetype", "linear"
        ));
    }
}
