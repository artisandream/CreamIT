using System;
using UnityEngine;

public class NextWave : MonoBehaviour {

	public static Action GoToNextWave;
	public static Action OnWinGame;
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
		StaticFunctions.totalRingCount--;
		if(StaticFunctions.totalRingCount == 0) {
			OnWinGame();
		}

		if(ringCount == 0) {
			GoToNextWave();
		}
	}
}
