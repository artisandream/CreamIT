using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicControler : MonoBehaviour {

	public AudioMixerSnapshot inActionColor;
	public AudioMixerSnapshot outActionColor;
	public float fadeIn;
	public float fadeOut;

	public void ColorActionStart()
	{
		inActionColor.TransitionTo(fadeIn);
	}

	public void ColorActionStop()
	{
		outActionColor.TransitionTo(fadeOut);
	}
}
