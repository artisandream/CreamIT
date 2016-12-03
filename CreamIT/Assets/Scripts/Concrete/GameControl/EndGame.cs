using UnityEngine;
using System;

public class EndGame : MonoBehaviour {

	public static Action GameOver;

	void OnTriggerEnter(Collider other)
	{
		GameOver();
	}
}
