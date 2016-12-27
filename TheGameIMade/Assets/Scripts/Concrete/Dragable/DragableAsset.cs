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
        Invoke("StartLate", 1);
       
        thisAnims = GetComponent<Animator>();
        OnReset(false);
		RunGame.ResetWave += OnReset;
		RunGame.RestartWave += OnRestart;
    }

    void StartLate() {
         SendToGenerator(this);
    }
	
	public virtual void OnReset(bool _bool)
    {
        thisAnims.SetBool("Reset", _bool);
    } 

    private void OnRestart()
    {
        OnReset(false);
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
