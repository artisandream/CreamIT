using System;
using Concrete.GameControl;
using Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Concrete.GUI
{
	public class StartButton : MonoBehaviour, IReset {

		public Animator uiAnims;
		public static Action StartButtonCall;
		Button startButton;

		public void Start()
		{
			startButton = GetComponent<Button>();
			startButton.onClick.AddListener(() => OnRestart());
			OnReset(true);
			RunGame.ResetWave += OnReset;

		}

		public void OnReset(bool _bool)
		{
			uiAnims.SetBool("Start", _bool);
		}

		public void OnRestart()
		{
			StartButtonCall();
			OnReset(false);
		}
	}
}
