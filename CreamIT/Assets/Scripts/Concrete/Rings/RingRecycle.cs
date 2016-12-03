using UnityEngine;
using System;

public class RingRecycle : MonoBehaviour, IReset {

	public static Action<NavAgent> SendToGenerator;
	public NavAgent navAgent;
	public SpriteRenderer center;
	public Material black;

	public void Start()
	{
		OnRestart();
		ResetGame.ResetLevel += OnReset;
		ResetGame.RestartLevel += OnRestart;
	}
	
	void OnTriggerEnter()
	{
		OnReset();
		SendToGenerator(navAgent);
	}

    public void OnReset()
    {
        center.material = black;
		navAgent.StopAgent();
    }

    public void OnRestart()
    {
        SendToGenerator(navAgent);
    }
}
