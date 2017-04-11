using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GloboInfo : MonoBehaviour
{
    public string title;
    public Text field;
	public Image globo;
	private float lineHeignt = 20;

    void OnEnable()
    {
        Events.OnGloboSimpleOff += OnGloboSimpleOff;
        Events.ConversationKill += ConversationKill;
    }
    void OnDisable()
    {
        Events.OnGloboSimpleOff -= OnGloboSimpleOff;
        Events.ConversationKill -= ConversationKill;
    }
    void OnGloboSimpleOff(string _title)
    {
        if (title == _title)
            Destroy(gameObject);
    }
    public void Init(string _title, string text)
    {
		this.title = _title;
        field.text = text;
		int _h = (text.Length / 20);
		float _height = 50 + (lineHeignt*_h);
		globo.GetComponent<RectTransform> ().sizeDelta = new Vector2 (globo.GetComponent<RectTransform> ().sizeDelta.x, _height);
    }
    public void InitAndReset(string title, string text, int resetTime = 3)
    {
        this.title = title;
        field.text = text;
        Invoke("Reset", resetTime);
    }
    void ConversationKill(string _title)
    {
        if (title == _title) Reset();
    }
    void Reset()
    {
        if(gameObject != null)
            Destroy(gameObject);
    }

}
