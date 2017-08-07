using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour {

	public AudioClip  cash;
	public AudioClip  waterDrop;
	public AudioClip  woodPop;
	public AudioClip  buttonClick;
	public AudioClip  perinola;
	public AudioClip  applause;
	public AudioClip  guitar;

	private AudioSource audioSource;

	void Start () {		
		audioSource = GetComponent<AudioSource> ();
		Events.OnSFX += OnSFX;
	}
	void OnSFX (AudioClip clipName) {
			
		audioSource.clip = clipName;		
		audioSource.Play ();
	}
}
