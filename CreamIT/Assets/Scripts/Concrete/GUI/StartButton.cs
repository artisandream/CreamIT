using UnityEngine;
using System;

public class StartButton : MonoBehaviour {

	public Animator uiAnims;
	public static Action CallStart;

	void Start()
	{
		uiAnims.SetBool("True", false);
		ResetGame.ResetLevel += OnResetButton;
	}

    private void OnResetButton()
    {
        uiAnims.SetBool("True", false);
    }

    public void OnStartGame () {
		CallStart();
		uiAnims.SetBool("Start", false);
	}

}
