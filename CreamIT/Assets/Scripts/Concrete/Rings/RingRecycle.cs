using UnityEngine;
using System;
using System.Collections;

public class RingRecycle : MonoBehaviour {

	public static Action<NavAgent> SendToGenerator;
	public NavAgent navAgent;
	public SpriteRenderer center;
	public Material black;

	void Start()
	{
		SendToGenerator(navAgent);
		ResetGame.ResetLevel += ResetRing;
		ResetGame.ResetLevel += EndRing;
	}
	
	void OnTriggerEnter()
	{
		print("h");
		ResetRing();
		SendToGenerator(navAgent);
	}

	private void EndRing ()
	{
		//Call animation to scale
	}

    private void ResetRing()
    {
        center.material = black;
		navAgent.StopAgent();
    }
}
