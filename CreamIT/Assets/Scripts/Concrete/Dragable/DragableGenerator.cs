using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class DragableGenerator : MonoBehaviour, IReset
{

    public List<Transform> startpointList;
    public List<DragObject> dragableList;
    public Transform dragableOffScreen;

    public void Start()
    {
        DragableStartPoint.SendToGenerator += AddToStartPointList;
        DragObject.SendToGenerator += AddToDragableList;
        DragObject.ReturnToGenerator += ResetStartPoint;
        ResetGame.ResetLevel += OnReset;
        ResetGame.RestartLevel += OnRestart;
    }

    private void OnStartGameHandler()
    {
        StartCoroutine(SetDrabables());
    }

    public void OnRestart()
    {
        StartCoroutine(SetDrabables());
    }

    private void ResetStartPoint(Transform startPoint, DragObject dragable)
    {
        startpointList.Add(startPoint);
        dragable.transform.position = dragableOffScreen.position;
        StartCoroutine(ResetDrabables(dragable));
    }

    private void AddToStartPointList(Transform obj)
    {
        startpointList.Add(obj);
    }

    private void AddToDragableList(DragObject obj)
    {
        dragableList.Add(obj);
        obj.transform.position = dragableOffScreen.position;
    }

    IEnumerator SetDrabables()
    {
        yield return new WaitForSeconds(StaticVars.appearTime);
        int i = dragableList.Count - 1;
        while (i >= 0)
        {
			yield return new WaitForSeconds(StaticVars.appearTime);
			SetDrabablesHandler(dragableList[i]);
            i--;
        }
    }
    
    private IEnumerator ResetDrabables(DragObject dragable)
    {
		yield return new WaitForSeconds(StaticVars.appearTime);
        SetDrabablesHandler(dragable);
    }

    void SetDrabablesHandler(DragObject dragable)
    {
        int r = UnityEngine.Random.Range(0, startpointList.Count - 1);
        dragable.transform.position = startpointList[r].position;
        dragable.lastStartPoint = startpointList[r];
        startpointList.RemoveAt(r);
    }

    public void OnReset()
    {
        startpointList.Clear();
    }
}
