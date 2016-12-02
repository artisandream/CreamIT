using UnityEngine;
using System.Collections;
using System;

public class StartGame : MonoBehaviour
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
    
    void Start()
    {
        StaticVars.appearTime = appearTime;
        StaticVars.generateTime = generateTime;
        StaticVars.moveSpeed = moveSpeed;
        StartButton.CallStart += OnStartGameHandler;
        StaticVars.addSpeed = addSpeed;
        ResetGame.ResetLevel += OnResetLevel;
    }

    private void OnResetLevel()
    {
        StopAllCoroutines();
    }

    void OnStartGameHandler () {
        OnStartGame();
        StartCoroutine(ModGame());
    }

    IEnumerator ModGame()
    {
        while (timesToMod > 0)
        {
            yield return new WaitForSeconds(GameModTime);
            StaticVars.moveSpeed += modFactor;
            StaticVars.generateTime /= modFactor;
            OnModGame();
			timesToMod--;
        }
    }
}
