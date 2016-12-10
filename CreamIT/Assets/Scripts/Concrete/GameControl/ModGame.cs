using System;
using System.Collections;
using UnityEngine;

public class ModGame : MonoBehaviour
{

    public static Action<float> ModSpeed;
    public static Action<float> ModGenTime;
    public float newSpeed;
    public float newGenTime;
    public float modNum;
    void Start()
    {
        NextWave.GoToNextWave += StartModGame;
		RunGame.OnStartWave += StartModGame;
        EndGame.GameOver += StopModGame;
    }

    private void StopModGame()
    {
		StaticFunctions.addedRingCount = 0;
    }

    private void StartModGame()
    {
		print("call");
		StaticFunctions.addedRingCount++;
        newSpeed = StaticFunctions.currentWave.ringMoveSpeed;
        StartCoroutine(ChangeSpeed());
    }

    IEnumerator ChangeSpeed()
    {
        modNum = StaticFunctions.currentWave.waveModCount;
        while (modNum > 0)
        {
	        yield return new WaitForSeconds(StaticFunctions.currentWave.waveModTimeHold);
            newSpeed = StaticFunctions.ChangeSpeed(StaticFunctions.currentWave.ringAddSpeed);
            newGenTime = StaticFunctions.currentWave.ringGenerateTime;
            StaticFunctions.ChangeGenTime(StaticFunctions.currentWave.ringAddSpeed);
            modNum--;
        }
		print("done");
    }
}
