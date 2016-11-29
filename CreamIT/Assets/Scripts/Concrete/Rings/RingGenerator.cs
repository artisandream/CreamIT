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
		StartCoroutine(RecycleColors());
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
