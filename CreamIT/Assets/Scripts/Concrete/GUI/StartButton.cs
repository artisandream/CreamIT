using UnityEngine;
using UnityEngine.UI;
using System;

public class StartButton : MonoBehaviour, IReset {

	public Animator uiAnims;
	public static Action StartButtonCall;
	Button startButton;

	public void Start()
	{
		startButton = GetComponent<Button>();
		startButton.onClick.AddListener(() => OnRestart());
		uiAnims.SetBool("Start", true);
		RunGame.ResetLevel += OnReset;
	}

    public void OnReset()
    {
        uiAnims.SetBool("Start", true);
    }

    public void OnRestart()
    {
        StartButtonCall();
		uiAnims.SetBool("Start", false);
    }
}
