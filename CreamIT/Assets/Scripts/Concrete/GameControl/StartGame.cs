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
    public float appearTime = 0.2f;
    public int timesToMod = 3;
    public float modFactor = 2;
    void Start()
    {
        StaticVars.appearTime = appearTime;
        StaticVars.generateTime = generateTime;
        StaticVars.moveSpeed = moveSpeed;
        StartButton.CallStart += OnStartGameHandler;
    }

    void OnStartGameHandler () {
        OnStartGame();
        StartCoroutine(ModGame());
    }

    IEnumerator ModGame()
    {
        while (timesToMod > 0)
        {
			print("mod");
            yield return new WaitForSeconds(GameModTime);
            StaticVars.moveSpeed += modFactor;
            StaticVars.generateTime /= modFactor;
            OnModGame();
			timesToMod--;
        }
    }
}
