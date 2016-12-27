    using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;

public class RunGame : MonoBehaviour
{
    public static Action OnStartWave;
    public static Action<float> SetSpeed;
    public List<WaveObject> WaveObjectList;
    public static Action<float> OnModSpeed;
    public static Action<bool> ResetWave;
    public static Action RestartWave;
    public static Action PlayNextWave;
    int nextWaveNum = 0;

    public float newSpeed;
    public float newGenTime;
    public float modNum;

    public void Start()
    {
        WaveObject.SendWave += AddToWaveObjectList;
        StartButton.StartButtonCall += OnStartButton;
        //CheckWave();
        Invoke("CheckWave", 0.01f);
        NextWave.GoToNextWave += StartModGame;
        NextWave.GoToNextWave += GoToNextWaveHandler;
        EndGame.GameOver += OnReset;
    }

    private void AddToWaveObjectList(WaveObject obj)
    {
        WaveObjectList.Add(obj);
    }

    private void OnStartButton()
    {
        nextWaveNum = 0;
        OnRestart(RestartWave);
    }
    
    private void GoToNextWaveHandler()
    {
        if (nextWaveNum < WaveObjectList.Count - 1)
        {
            nextWaveNum++;
        }
        else
        {
            nextWaveNum = 0;
        }
        OnRestart(PlayNextWave);
    }

    public void OnReset()
    {
        ResetWave(true);
        StaticFunctions.addedRingCount = 0;
    }
    
    public void OnRestart(Action SendAction)
    {
        CheckWave();
        SetSpeed(StaticFunctions.SetSpeed());
        StaticFunctions.SetGenTime(StaticFunctions.currentWave.ringGenerateTime);
        OnStartWave();
        StartModGame();
        SendAction();
    }

    private void CheckWave()
    {
        StaticFunctions.currentWave = WaveObjectList[nextWaveNum];
    }

    private void StartModGame()
    {
        StartCoroutine(ModSpeed());
    }

    IEnumerator ModSpeed()
    {
        StaticFunctions.addedRingCount++;
        newSpeed = StaticFunctions.currentWave.ringMoveSpeed;
        modNum = StaticFunctions.currentWave.waveModCount;
        while (modNum > 0)
        {
	        yield return new WaitForSeconds(StaticFunctions.currentWave.waveModTimeHold);
            newSpeed = StaticFunctions.OnModSpeed();
            newGenTime = StaticFunctions.currentWave.ringGenerateTime;
            StaticFunctions.ChangeGenTime();
            modNum--;
            OnModSpeed(newSpeed);
        }
    }
}
