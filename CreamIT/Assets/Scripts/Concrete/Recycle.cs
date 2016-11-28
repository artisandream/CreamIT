using UnityEngine;
using System;

public class Recycle : MonoBehaviour {

	public static Action<NavAgent> SendToGenerator;
	public NavAgent navAgent;
	public SpriteRenderer center;
	public Material black;

	void Start()
	{
		SendToGenerator(navAgent);
	}
	
	void OnTriggerEnter()
	{
		center.material = black;
		navAgent.StopAgent();
		SendToGenerator(navAgent);
	}
}
