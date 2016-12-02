using UnityEngine;
using System;

public class StartButton : MonoBehaviour {

	public Animator uiAnims;
	public static Action CallStart;
	// Use this for initialization
	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
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
