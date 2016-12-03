using UnityEngine;
using System.Collections;
using System;

public class StartGame : MonoBehaviour, IReset
{
    public static Action OnStartGame;
    public static Action OnModGame;
    public int GameModTime = 15;
    public float generateTime = 2f;
    public float moveSpeed = 3.5f;
    public float addSpeed = 0.1f;
    public float appearTime = 0.2f;
    public int timesToMod = 3;
    public float modFactor = 2;
    
    public void Start()
    {
        SetStartValues();
        ResetGame.RestartLevel += OnRestart;
        ResetGame.ResetLevel += OnReset;
    }

    void SetStartValues () {
        StaticVars.appearTime = appearTime;
        StaticVars.generateTime = generateTime;
        StaticVars.moveSpeed = moveSpeed;
        StaticVars.addSpeed = addSpeed;
    }

    public void OnReset()
    {
        SetStartValues();
        StopAllCoroutines();
    }

    IEnumerator ModGame()
    {
        int tempModTimes = timesToMod;
        while (timesToMod > 0)
        {
            yield return new WaitForSeconds(GameModTime);
            StaticVars.moveSpeed += modFactor;
            StaticVars.generateTime /= modFactor;
            OnModGame();
			timesToMod--;
        }
        timesToMod = tempModTimes;
    }

    public void OnRestart()
    {
        StartCoroutine(ModGame());
    }
}
