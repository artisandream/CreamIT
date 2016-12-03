using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class RingGenerator : MonoBehaviour, IReset {
	public int agentCount = 20;
	public List<NavAgent> RecycleList;
	public Transform rignOffScreen;
	public Transform destination;

	public void Start () {
		RingRecycle.SendToGenerator += AddToList;
		ResetGame.ResetLevel += OnReset;
		ResetGame.RestartLevel += OnRestart;
	}

	public void OnReset()
    {
		StopAllCoroutines();
		RecycleList.Clear();	
    }

    private void AddToList(NavAgent obj)
    {
        RecycleList.Add(obj);
		obj.transform.position = rignOffScreen.position;
	}

    IEnumerator RecycleColors () {
		while(agentCount > 0){
			yield return new WaitForSeconds(StaticVars.generateTime);
			RecycleList[0].transform.position = transform.position;
			RecycleList[0].OnSet(destination);
			RecycleList.RemoveAt(0);
			agentCount--;
		}
	}

    public void OnRestart()
    {
        StartCoroutine(RecycleColors());
    }
}
