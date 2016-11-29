using UnityEngine;
using System;
public class DragObject : MonoBehaviour
{

	public static Action<Transform> SendToGenerator;
	
	void Start () {
		SendToGenerator(transform);
	}
    private Vector3 offset;
    void OnMouseDown()
    {
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
    }
}
