using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DragableGenerator : MonoBehaviour {

	public List<Transform> startpointList;
	public List<Transform> dragableList;
	public Transform dragableOffScreen;
	
	void Start()
	{
		DragableStartPoint.SendToGenerator += AddToStartPointList;
		DragObject.SendToGenerator += AddToDragableList;
		StartCoroutine(SetDrabables());
	}

    private void AddToStartPointList(Transform obj)
    {
        startpointList.Add(obj);
	}

	private void AddToDragableList(Transform obj)
    {
        dragableList.Add(obj);
		obj.position = dragableOffScreen.position;
	}
    IEnumerator SetDrabables () {
		yield return new WaitForSeconds(StaticVars.generateTime);
		print(3);
		int i = dragableList.Count-1;
		int r = Random.Range(0, startpointList.Count-1);
		while(startpointList.Count > 0){
			yield return new WaitForSeconds(StaticVars.generateTime);
			dragableList[i].position = startpointList[r].position;
			startpointList.RemoveAt(0);
			i--;
		}
	}
}
