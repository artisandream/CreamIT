using UnityEngine;
using System;

public class DragableStartPoint : MonoBehaviour {

	public static Action<Transform> SendToGenerator;

    public void OnRestart()
    {
        SendToGenerator(transform);
    }

    public void Start () {
		SendToGenerator(transform);
	}
	
}
