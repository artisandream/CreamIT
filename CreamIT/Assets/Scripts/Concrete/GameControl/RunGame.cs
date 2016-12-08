using UnityEngine;
using System.Collections.Generic;
using System;

public class RunGame : MonoBehaviour, IReset
{
    public static Action<LevelObject> OnStartLevel;
    public List<LevelObject> levelObjects;
    public LevelObject currentLevel;
    public static Action ResetLevel;
    public static Action RestartLevel;
    public static Action PlayNextLevel;
    int nextLevelNum = 0;

    public void Start()
    {
        EndGame.GameOver += OnReset;
        StartButton.StartButtonCall += OnStartButton;
        NextLevel.GoToNextLevel += GoToNextLevelHandler;
        Invoke("CheckLevel", 0.01f);
    }

    private void OnStartButton()
    {
        nextLevelNum = 0;
        OnRestart();
    }

    private void GoToNextLevelHandler()
    {
        if (nextLevelNum < levelObjects.Count - 1)
        {
            nextLevelNum++;
        }
        else
        {
            nextLevelNum = 0;
        }
        OnPlayNextLevel();
    }

    private void OnPlayNextLevel()
    {
        CheckLevel();
        OnStartLevel(currentLevel);
        PlayNextLevel();
    }

    public void OnReset()
    {
        ResetLevel();
    }

    public void OnRestart()
    {
        CheckLevel();
        OnStartLevel(currentLevel);
        RestartLevel();
    }

    private void CheckLevel()
    {
        currentLevel = levelObjects[nextLevelNum];
    }
}
