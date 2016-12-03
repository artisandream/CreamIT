using UnityEngine;
using System;

public class RingRecycle : MonoBehaviour, IReset {

	public static Action<NavAgent> SendToGenerator;
	public NavAgent navAgent;
	public SpriteRenderer center;
	public Material black;

	public void Start()
	{
		SendToGenerator(navAgent);
		ResetGame.ResetLevel += OnReset;
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
        throw new NotImplementedException();
    }
}
