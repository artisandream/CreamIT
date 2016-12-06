using UnityEngine;
using System;

public class DragObject : MonoBehaviour
{
    public static Action<DragObject> SendToGenerator;
    public static Action<Transform, DragObject> ReturnToGenerator;
    public Transform lastStartPoint;
    public Transform StartPoint;
    private Vector3 offset;
    
    void Start()
    {
        //RunGame.RestartLevel += OnRestart;
        SendToGenerator(this);
    }

    private void OnRestart()
    {
        transform.position = StartPoint.localPosition;
    }

    void OnMouseDown()
    {
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
    }

    void OnMouseUp()
    {
        ReturnToGenerator(lastStartPoint, this);
    }
}
