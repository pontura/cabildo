using UnityEngine;
using System.Collections;

public class BochaBall : MonoBehaviour {

    public int id;

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.GetComponent<BochasWall>())
        {
            GetComponent<Rigidbody>().AddForce(c.contacts[0].normal * 150, ForceMode.Impulse);
        }
    }
}
