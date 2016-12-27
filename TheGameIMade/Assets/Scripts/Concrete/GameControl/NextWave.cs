using System;
using UnityEngine;

public class NextWave : MonoBehaviour {

	public static Action GoToNextWave;
	public int ringCount;

	void Start()
	{
		RunGame.OnStartWave += OnStartWaveHandler;
	}

    private void OnStartWaveHandler()
    {
		ringCount = StaticFunctions.currentWave.ringCount;
    }

	void OnTriggerEnter(Collider other)
	{
		ringCount--;
		if(ringCount == 0) {
			GoToNextWave();
		}
	}
}
