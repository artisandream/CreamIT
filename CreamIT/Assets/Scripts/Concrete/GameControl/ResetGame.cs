using UnityEngine;
using System;

public class ResetGame : MonoBehaviour {

	public static Action ResetLevel;
	
	void Start(){
		EndGame.GameOver += OnReset;
	}
	void OnReset () {
		ResetLevel();
	}
}
