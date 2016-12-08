using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class RingGenerator : MonoBehaviour, IReset {

	private int ringCount;
	public Transform rignRelocation;
	public Transform destination;
	private LevelObject currentLevel;
	public List<RingAsset> RingAssetList;
	

	public void Start () {
		RingAsset.SendToGenerator += AddToList;
		RunGame.OnStartLevel += OnStartLevelHandler;
		RunGame.ResetLevel += OnReset;
		RunGame.RestartLevel += OnRestart;
		RunGame.PlayNextLevel += OnRestart;
		ModGame.ModSpeed += ModGeneratorSpeed;
	}

    private void ModGeneratorSpeed(float obj)
    {
        throw new NotImplementedException();
    }

    private void OnStartLevelHandler(LevelObject obj)
    {
        currentLevel = obj;
		ringCount = currentLevel.ringCount;
    }

    public void OnReset()
    {
		StopAllCoroutines();
		RingAssetList.Clear();	
    }

    private void AddToList(RingAsset obj)
    {
        RingAssetList.Add(obj);
		obj.transform.position = rignRelocation.position;
	}

    IEnumerator RecycleRings () {
		while(ringCount > 0){
			yield return new WaitForSeconds(currentLevel.ringGenerateTime);
			RingAssetList[0].transform.position = transform.position;
			RingAssetList[0].OnSet(destination);
			RingAssetList.RemoveAt(0);
			ringCount--;
		}
	}

    public void OnRestart()
    {
		ringCount = currentLevel.ringCount;
        StartCoroutine(RecycleRings());
    }
}