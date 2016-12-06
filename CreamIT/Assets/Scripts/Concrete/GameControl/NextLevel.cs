using System;
using UnityEngine;

public class NextLevel : MonoBehaviour {

	public static Action GoToNextLevel;
	private LevelObject currentLevel;
	public int ringCount;

	void Start()
	{
		RunGame.OnStartLevel += OnStartLevelHandler;
	}

    private void OnStartLevelHandler(LevelObject obj)
    {
        currentLevel = obj;
		ringCount = currentLevel.ringCount;
    }

	void OnTriggerEnter(Collider other)
	{
		ringCount--;
		if(ringCount == 0) {
			GoToNextLevel();
		}
	}
}
