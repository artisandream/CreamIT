using UnityEngine;
using System;

public class DragableStartPoint : MonoBehaviour {

	public static Action<Transform> SendToGenerator;
	
	void Start () {
		SendToGenerator(transform);
	}
	
}
