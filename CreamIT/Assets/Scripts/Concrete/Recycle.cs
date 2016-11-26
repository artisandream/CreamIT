using UnityEngine;
using System;

public class Recycle : MonoBehaviour {

	public static Action<NavAgent> SendToGenerator;
	public NavAgent navAgent;

	void Start()
	{
		SendToGenerator(navAgent);
	}
	
	void OnTriggerEnter()
	{
		navAgent.StopAgent();
		SendToGenerator(navAgent);
	}
}
