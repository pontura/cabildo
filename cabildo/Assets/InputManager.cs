using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputManager : MonoBehaviour {

	public Text field;
	public Camera main;

	float lastClickLeft;
	float clicksDelayLeft = 0.3f;

	float lastClickRight;
	float clicksDelayRight =  0.3f;

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Q))
			Application.Quit ();



		bool clicked = false;
		foreach (Touch touch in Input.touches) {
			if (touch.phase == TouchPhase.Began && !clicked) {				
				ClickenOn (touch.position);
				clicked = true;
			}

		}


		////////////////Borrar para el build
		//		if (clicked)
		//			return;
		//		
		//		if(Input.GetMouseButtonDown(0))
		//		{
		//			ClickenOn(Input.mousePosition);
		//		}		/// ////////////////////////////////
	}
	void ClickenOn(Vector3 pos)
	{
		if (Input.touches.Length>0 &&  UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
			return;
		//		else if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(-1))
		//			return;

		Vector3 mousePos = pos;
		mousePos.z = 10;

		Vector3 screenPos = main.ScreenToWorldPoint(mousePos);
		CheckColliderIn(screenPos, mousePos.x);
	}
	public void PopupClicked()
	{      
		Vector3 mousePos = Vector3.zero;	

		bool clicked = false;
		if (Input.touches.Length > 0) {
			foreach (Touch touch in Input.touches) {
				mousePos = touch.position;
			}
		}
		else if(Input.mousePosition != null) {
			//mousePos = Input.mousePosition;
		}


		if (mousePos == Vector3.zero)
			return;
		mousePos.z = 10;

		//field.text = id + " Popup " + mousePos;

		Vector3 screenPos = main.ScreenToWorldPoint(mousePos);
		screenPos.x -= 18.6f;
		CheckColliderIn(screenPos, mousePos.x);
	}
	int id = 0;
	void CheckColliderIn(Vector3 pos, float mousePos)
	{		
		bool isLeft = false;
		id++;
		if (mousePos - (Screen.width / 2) < 0) {

			isLeft = true;
			if (Time.time - clicksDelayLeft < lastClickLeft) {
				//field.text += id + "__L ";
				return;
			}
			lastClickLeft = Time.time;

			//field.text = id + "L ";
		} else {
			if (Time.time - clicksDelayRight < lastClickRight) {
				//field.text += id + "___R ";
				return;
			}
			lastClickRight = Time.time;

			//field.text = id + "R ";
		}

		RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
		if (hit)
		{
			Events.OnClick(pos, hit.transform.gameObject.name);
		} else
		{
			//            if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(-1))
			//                return;
			//Events.OnClickOutside(isLeft);
		}

	}
}





//
//using UnityEngine;
//using System.Collections;
//using UnityEngine.UI;
//
//public class InputManager : MonoBehaviour {
//
//	public Text field;
//    public Camera main;
//
//	float lastClickLeft;
//	float clicksDelayLeft = 0.3f;
//
//	float lastClickRight;
//	float clicksDelayRight =  0.3f;
//
//    void Update()
//    {
//		if (Input.GetKeyDown (KeyCode.Q))
//			Application.Quit ();
//
//
//		
//		bool clicked = false;
//		foreach (Touch touch in Input.touches) {
//			if (touch.phase == TouchPhase.Began && !clicked) {				
//				ClickenOn (touch.position);
//				clicked = true;
//			}
//
//		}
//
//
//		//////////////Borrar para el build
//		if (clicked)
//			return;
//		
//		if(Input.GetMouseButtonDown(0))
//		{
//			ClickenOn(Input.mousePosition);
//		}		/// ////////////////////////////////
//    }
//	void ClickenOn(Vector3 pos)
//	{
//		if (Input.touches.Length>0 &&  UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
//			return;
//		else if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(-1))
//			return;
//		
//		Vector3 mousePos = pos;
//		mousePos.z = 10;
//
//		Vector3 screenPos = main.ScreenToWorldPoint(mousePos);
//		CheckColliderIn(screenPos, mousePos.x);
//	}
//    public void PopupClicked()
//    {      
//		Vector3 mousePos = Vector3.zero;	
//
//		bool clicked = false;
//		if (Input.touches.Length > 0) {
//			foreach (Touch touch in Input.touches) {
//				mousePos = touch.position;
//			}
//		}
//		else if(Input.mousePosition != null) {
//			mousePos = Input.mousePosition;
//		}
//
//
//		if (mousePos == Vector3.zero)
//			return;
//        mousePos.z = 10;
//
//		//field.text = id + " Popup " + mousePos;
//
//        Vector3 screenPos = main.ScreenToWorldPoint(mousePos);
//        screenPos.x -= 18.6f;
//		CheckColliderIn(screenPos, mousePos.x);
//    }
//	int id = 0;
//	void CheckColliderIn(Vector3 pos, float mousePos)
//    {		
//		bool isLeft = false;
//		id++;
//		if (mousePos - (Screen.width / 2) < 0) {
//			
//			isLeft = true;
//			if (Time.time - clicksDelayLeft < lastClickLeft) {
//				//field.text += id + "__L ";
//				return;
//			}
//			lastClickLeft = Time.time;
//
//			//field.text = id + "L ";
//		} else {
//			if (Time.time - clicksDelayRight < lastClickRight) {
//				//field.text += id + "___R ";
//				return;
//			}
//			lastClickRight = Time.time;
//
//			//field.text = id + "R ";
//		}
//		
//        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
//        if (hit)
//        {
//            Events.OnClick(pos, hit.transform.gameObject.name);
//        } else
//        {
//            if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(-1))
//                return;
//			Events.OnClickOutside(isLeft);
//        }
//        
//    }
//}
