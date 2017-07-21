using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTalk : MonoBehaviour {

	public int timeOut;
	bool paused;
	void Start()
	{
		Events.OnClick += OnClick;
		Events.ConversationKill += ConversationKill;
	}
	void OnDestroy()
	{
		Events.OnClick -= OnClick;
		Events.ConversationKill -= ConversationKill;
	}
	void OnClick(Vector3 pos, string title)
	{

		if (paused || title != gameObject.name) return;

		paused = true;
		iTween.Pause(gameObject);
		Vector3 pos3 = Input.mousePosition;
		pos3.x -= Screen.width / 2;
		pos3.y -= Screen.height / 2;
		string text = Data.Instance.conversaciones.GetSimpleText(title);
		Events.OnGloboSimpleTimeOut (title, new Vector2(pos3.x-10, pos3.y+50), text, timeOut);
	}
	void ConversationKill(string title)
	{
		if (title != gameObject.name) return;
		iTween.Resume(gameObject);
		paused = false;
	}
}
