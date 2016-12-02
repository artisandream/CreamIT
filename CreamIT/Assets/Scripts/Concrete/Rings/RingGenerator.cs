using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RingGenerator : MonoBehaviour {
	public int agentCount = 20;
	public List<NavAgent> RecycleList;
	public Transform rignOffScreen;
	public Transform destination;

	void Start () {
		RingRecycle.SendToGenerator += AddToList;
		StartGame.OnStartGame += OnStartGameHandler;
		ResetGame.ResetLevel += OnResetGameHandler;
	}

    private void OnStartGameHandler()
    {
        StartCoroutine(RecycleColors());
    }

	private void OnResetGameHandler()
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
			RecycleList[0].ResetAgent(destination);
			RecycleList.RemoveAt(0);
			agentCount--;
		}
	}
}
