using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Generator : MonoBehaviour {
	public int agentCount = 20;
	public List<NavAgent> RecycleList;
	public Transform navPen;
	public Transform destination;

	void Start () {
		Recycle.SendToGenerator += AddToList;
		StartCoroutine(RecycleColors());
	}

    private void AddToList(NavAgent obj)
    {
        RecycleList.Add(obj);
		obj.transform.position = navPen.position;
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
