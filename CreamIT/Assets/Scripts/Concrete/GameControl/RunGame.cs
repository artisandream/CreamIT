using UnityEngine;
using System.Collections.Generic;
using System;

public class RunGame : MonoBehaviour, IReset
{
    public static Action OnStartWave;
    public static Action<float> SetSpeed;
    public List<WaveObject> waveObjects;
    public static Action ResetWave;
    public static Action RestartWave;
    public static Action PlayNextWave;
    int nextWaveNum = 0;

    public void Start()
    {
        EndGame.GameOver += OnReset;
        StartButton.StartButtonCall += OnStartButton;
        NextWave.GoToNextWave += GoToNextWaveHandler;
        CheckWave();
        Invoke("CheckWave", 0.01f);
    }

    private void OnStartButton()
    {
        nextWaveNum = 0;
        OnRestart();
        
    }

    private void GoToNextWaveHandler()
    {
        if (nextWaveNum < waveObjects.Count - 1)
        {
            nextWaveNum++;
        }
        else
        {
            nextWaveNum = 0;
        }
        OnPlayNextWave();
    }

    private void OnPlayNextWave()
    {
        CheckWave();
        OnStartWave();
        PlayNextWave();
    }

    public void OnReset()
    {
        ResetWave();
    }

    public void OnRestart()
    {
        CheckWave();
        OnStartWave();
        RestartWave();
    }

    private void CheckWave()
    {
        StaticFunctions.currentWave = waveObjects[nextWaveNum];
    }
}
