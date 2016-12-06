using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class RunGame : MonoBehaviour, IReset
{

    public static Action<LevelObject> OnStartLevel;
    public static Action<LevelObject> OnModGame;
    public List<LevelObject> levelObjects;
    public LevelObject currentLevel;
    public static Action ResetLevel;
    public static Action RestartLevel;

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
        if (nextLevelNum < levelObjects.Count-1)
        {
            nextLevelNum++;
        }
        else
        {
            nextLevelNum = 0;
        }
        OnRestart();
    }

    int nextLevelNum = 0;

    public void OnReset()
    {
        StopAllCoroutines();
        ResetLevel();
    }

    public void OnRestart()
    {
        StopAllCoroutines();
        CheckLevel();
        OnStartLevel(currentLevel);
        StartCoroutine(ModGame());
        RestartLevel();
    }

    private void CheckLevel()
    {
        currentLevel = levelObjects[nextLevelNum];
    }

    IEnumerator ModGame()
    {
        int currentLevelModeCount = currentLevel.levelModCount;
        while (currentLevelModeCount > 0)
        {
            yield return new WaitForSeconds(currentLevel.levelModTimeHold);
            OnModGame(currentLevel);
            currentLevelModeCount--;
        }
    }
}
