using UnityEngine;
using System.Collections;

public static class Events
{
    public static System.Action ResetApp = delegate { };
    public static System.Action<string> SetSignalText = delegate { };
	public static System.Action<AudioClip> OnSFX = delegate { };
    
    public static System.Action<string> ConversationKill = delegate { };
    public static System.Action<string> OnGloboSimpleOff = delegate { };
    
    public static System.Action OnMinigameReady = delegate { };
    public static System.Action<Cocina.minigames> OnMinigameCocinaReady = delegate { };
    public static System.Action OnMinigameBanioReady = delegate { };
	public static System.Action OnMinigameBochasReady = delegate { };
    public static System.Action<Vector3, string> OnClick = delegate { };

    public static System.Action ResetGlobos = delegate { };
    public static System.Action ResetGlobos2 = delegate { };
    public static System.Action<GlobosManager.sides> ResetPopup = delegate { };
    public static System.Action<string> OnGloboPopup = delegate { };
    public static System.Action<string> OnGlobo2Popup = delegate { };
    public static System.Action<string, Vector2, string> OnGloboSimple = delegate { };
	public static System.Action<string, Vector2, string, int> OnGloboSimpleTimeOut = delegate { };

    public static System.Action<Vector2, string> OnGloboMultipleChoice = delegate { };
    public static System.Action<Vector2, string, int> OnGloboSimpleAbajo = delegate { };    

    public static System.Action OnHeaderOff = delegate { };
    public static System.Action OnHeader2Off = delegate { };
    public static System.Action<bool> OnClickOutside = delegate { };

    public static System.Action<UICocina.recetas> OnVerReceta = delegate { };
    

}
   
