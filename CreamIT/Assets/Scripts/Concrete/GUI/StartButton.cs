using UnityEngine;
using System;

public class StartButton : MonoBehaviour {

	public Animator uiAnims;
	public static Action CallStart;
	// Use this for initialization
	public void OnStartGame () {
		CallStart();
		uiAnims.SetBool("Start", false);
	}

}
