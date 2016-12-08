using System;
using System.Collections;
using UnityEngine;

public class ModGame : MonoBehaviour {

	public static Action<float> ModSpeed;

	private LevelObject currentLevel;
	
	void Start () {
		RunGame.OnStartLevel += StartModGame;
		RunGame.RestartLevel += StopModGame;
	}

    private void StopModGame()
    {
        StopAllCoroutines();
    }

    private void StartModGame(LevelObject obj)
    {
		print("Start");
        currentLevel = obj;
    }

    IEnumerator ChangeSpeed () {
		print("Mod");
		yield return new WaitForSeconds(currentLevel.levelModTimeHold);
		ModSpeed(currentLevel.ringAddSpeed);
	}
}
