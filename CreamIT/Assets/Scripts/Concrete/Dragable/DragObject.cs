using UnityEngine;
using System;

public class DragObject : MonoBehaviour
{
    public static Action<DragObject> SendToGenerator;
    public static Action<Transform, DragObject> ReturnToGenerator;
    public Transform lastStartPoint;
    public Transform StartPoint;
    private Vector3 offset;

    private void Start()
    {
        SendToGenerator(this);
    }

    private void OnRestart()
    {
        transform.position = StartPoint.localPosition;
    }

    private void OnMouseDown()
    {
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
    }

    private void OnMouseUp()
    {
        ReturnToGenerator(lastStartPoint, this);
    }
}
