using System;
using System.Collections;
using UnityEngine;

public class ModGame : MonoBehaviour {

	public static Action<float> ModSpeed;

	private LevelObject currentLevel;
	
	void Start () {
		RunGame.OnStartLevel += StartModGame;
		EndGame.GameOver += StopModGame;
		//NextLevel.GoToNextLevel += StopModGame;
	}

    private void StopModGame()
    {
        StopAllCoroutines();
    }

    private void StartModGame(LevelObject obj)
    {
        currentLevel = obj;
		StartCoroutine(ChangeSpeed());
    }

    IEnumerator ChangeSpeed () {
		yield return new WaitForSeconds(1);
		ModSpeed(currentLevel.ringAddSpeed);
		StartCoroutine(ChangeSpeed());
	}
}
