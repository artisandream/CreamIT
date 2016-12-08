using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RingGenerator : MonoBehaviour, IReset {

	private int ringCount;
	public Transform rignRelocation;
	public Transform destination;
	private LevelObject currentLevel;
	public List<RingAsset> RecycleList;
	

	public void Start () {
		RingAsset.SendToGenerator += AddToList;
		RunGame.OnStartLevel += OnStartLevelHandler;
		RunGame.ResetLevel += OnReset;
		RunGame.RestartLevel += OnRestart;
		RunGame.PlayNextLevel += OnRestart;
	}

    private void OnStartLevelHandler(LevelObject obj)
    {
        currentLevel = obj;
		ringCount = currentLevel.ringCount;
    }

    public void OnReset()
    {
		StopAllCoroutines();
		RecycleList.Clear();	
    }

    private void AddToList(RingAsset obj)
    {
        RecycleList.Add(obj);
		obj.transform.position = rignRelocation.position;
	}

    IEnumerator RecycleColors () {
		while(ringCount > 0){
			yield return new WaitForSeconds(StaticVars.generateTime);
			RecycleList[0].transform.position = transform.position;
			RecycleList[0].OnSet(destination, currentLevel);
			RecycleList.RemoveAt(0);
			ringCount--;
		}
	}

    public void OnRestart()
    {
		ringCount = currentLevel.ringCount;
        StartCoroutine(RecycleColors());
    }
}