using Concrete.Color;
using Concrete.GameControl;
using Concrete.GUI;
using Concrete.Rings;
using UnityEngine;
using UnityEngine.Audio;

namespace Audio
{
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

		public AudioClip notMatchSound;
		public AudioSource notMatchSource;

		void Awake()
		{
			StartButton.StartButtonCall += PlayButtonSound;
			RunGame.OnStartWave += ColorActionStart;
			EndGame.GameOver += ColorActionStop;
			EndGame.GameOver += PlayOpenRingSound;
			RingAsset.RingOnWin += PlayCatchSound;
			ColorTrigger.ColorMatch += PlayMatchSound;
			ColorTrigger.ColorNotMatch += PlayNotMatchSound;
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

		public void PlayNotMatchSound()
		{
			notMatchSource.clip = notMatchSound;
			notMatchSource.Play();
		}
	}
}

