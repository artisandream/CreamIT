using System;
using UnityEngine;

public class RingStartPoint : MonoBehaviour {

public static Action<Transform> SendRingStartPoint;

	
	void Start () {
		SendRingStartPoint(transform);
	}

}
