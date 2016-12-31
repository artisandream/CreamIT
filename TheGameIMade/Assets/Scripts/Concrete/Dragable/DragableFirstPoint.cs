using System;
using UnityEngine;

public class DragableFirstPoint : MonoBehaviour {

	public static Action<Transform> SendToDragable;

    public void Start () {	
		SendToDragable(transform);
	}
}
