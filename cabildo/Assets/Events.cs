using UnityEngine;
using System.Collections;

public static class Events
{
    public static System.Action ResetApp = delegate { };
    public static System.Action<string> SetSignalText = delegate { };

    public static System.Action<Vector3, string> OnGloboDialogo = delegate { };
    


}
   
