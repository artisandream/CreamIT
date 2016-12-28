using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class MusicController : MonoBehaviour {

	public AudioMixerSnapshot inActionColor;
	public AudioMixerSnapshot outActionColor;
	public float fadeIn;
	public float fadeOut;

	public AudioClip buttonSound;
	public AudioSource buttonSoundSource;

	public AudioClip openRingSound;
	public AudioSource openRingSource;

	public AudioClip catchSound;
	public AudioSource catchSource;

	public AudioClip matchSound;
	public AudioSource matchSource;

	void Awake()
	{
		StartButton.StartButtonCall += PlayButtonSound;
		RunGame.OnStartWave += ColorActionStart;
		EndGame.GameOver += ColorActionStop;
		EndGame.GameOver += PlayOpenRingSound;
		RingAsset.RingOnWin += PlayCatchSound;
		ColorTrigger.ColorMatch += PlayMatchSound;
	}

	public void ColorActionStart()
	{
		inActionColor.TransitionTo(fadeIn);
	}

	public void ColorActionStop()
	{
		outActionColor.TransitionTo(fadeOut);
	}

	public void PlayButtonSound()
	{
		buttonSoundSource.clip = buttonSound;
		buttonSoundSource.Play();
	}

	public void PlayOpenRingSound()
	{
		openRingSource.clip = openRingSound;
		openRingSource.Play();
	}

	public void PlayCatchSound()
	{
		catchSource.clip = catchSound;
		catchSource.Play();
	}

	public void PlayMatchSound()
	{
		matchSource.clip = matchSound;
		matchSource.Play();
	}
}
