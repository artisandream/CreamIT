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
        StartButton.StartButtonCall += OnRestart;
        Invoke ("CheckLevel", 0.01f);
    }

    int i = 0;
  
    public void OnReset()
    {
        StopAllCoroutines();
        ResetLevel();
    }

    public void OnRestart()
    {
        CheckLevel();
		OnStartLevel(currentLevel);
        StartCoroutine(ModGame());
        RestartLevel();
    }

    private void CheckLevel()
    {
        currentLevel = levelObjects[0];
    }

    IEnumerator ModGame()
    {
        int currentLevelModeCount = currentLevel.levelModeCount;
        while (currentLevelModeCount > 0)
        {
            yield return new WaitForSeconds(currentLevel.levelModTimeHold);
			print(currentLevel);
            OnModGame(currentLevel);
            currentLevelModeCount--;
        }
    }
}
