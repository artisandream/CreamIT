using UnityEngine;
using System;

public class DragableAsset : MonoBehaviour
{
    public static Action<DragableAsset> SendToGenerator;
    public static Action<Transform, DragableAsset> ReturnToGenerator;
    public Transform lastStartPoint;
    public Transform StartPoint;
    private Vector3 offset;

    private Animator thisAnims;
    private void Start()
    {
        SendToGenerator(this);
        thisAnims = GetComponent<Animator>();
        thisAnims.SetBool("Reset", false);
		RunGame.ResetLevel += OnReset;
		RunGame.RestartLevel += OnRestart;
    }
	
	public virtual void OnReset()
    {
        thisAnims.SetBool("Reset", true);
    } 

    private void OnRestart()
    {
        thisAnims.SetBool("Reset", false);
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
