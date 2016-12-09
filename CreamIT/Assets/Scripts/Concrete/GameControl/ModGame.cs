using System;
using System.Collections;
using UnityEngine;

public class ModGame : MonoBehaviour {

	public static Action<float> ModSpeed;
	public static Action<float> ModGenTime;
	public float newSpeed;
	public float newGenTime;

	void Start () {
		RunGame.OnStartWave += StartModGame;
		EndGame.GameOver += StopModGame;
	}

    private void StopModGame()
    {
        StopAllCoroutines();
    }

    private void StartModGame()
    {
		newSpeed = StaticFunctions.currentWave.ringMoveSpeed;
		StartCoroutine(ChangeSpeed());
    }

    IEnumerator ChangeSpeed () {
		yield return new WaitForSeconds(StaticFunctions.currentWave.levelModTimeHold);
		newSpeed = StaticFunctions.ChangeSpeed(StaticFunctions.currentWave.ringAddSpeed);
		if(newGenTime > 0.1f)
			newGenTime -= StaticFunctions.ChangeGenTime(StaticFunctions.currentWave.ringAddSpeed);
		
		ModSpeed(newSpeed);
		StartCoroutine(ChangeSpeed());
	}
}
