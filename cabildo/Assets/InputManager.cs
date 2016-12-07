using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

    public Camera main;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10;

            Vector3 screenPos = main.ScreenToWorldPoint(mousePos);
            CheckColliderIn(screenPos);
        }
    }
    void CheckColliderIn(Vector3 pos)
    {
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
        if (hit)
        {
            if (hit.transform.gameObject.name == "camera_1_Collider")
            {
                pos.x -= 20;
                CheckColliderIn(pos);
            }
            else
            {
                print(hit.collider.name);
            }
        }
    }
}
