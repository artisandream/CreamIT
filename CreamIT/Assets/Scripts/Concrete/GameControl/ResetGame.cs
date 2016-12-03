using UnityEngine;
using System;

public class ResetGame : MonoBehaviour, IReset {

	public static Action ResetLevel;
	public static Action RestartLevel;
	
	public void Start(){
		EndGame.GameOver += OnReset;
		StartButton.StartButtonCall += OnRestart;
	}
	public void OnReset () {
		ResetLevel();
	}

    public void OnRestart()
    {
        RestartLevel();
    }
}
