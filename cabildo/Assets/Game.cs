using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour
{
    static Game mInstance;

    public static Game Instance
    {
        get
        {
            return mInstance;
        }
    }
    void Awake()
    {
        if (!mInstance)
            mInstance = this;
    }
}
