using UnityEngine;
using System;

public class ResetGame : MonoBehaviour {

	public static Action ResetLevel;
	// Use this for initialization
	
	void Start(){
		EndGame.GameOver += OnReset;

	}
	void OnReset () {
		ResetLevel();
	}
}
