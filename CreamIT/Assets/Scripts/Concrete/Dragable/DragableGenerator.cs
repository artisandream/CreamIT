using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class DragableGenerator : MonoBehaviour
{

    public List<Transform> startpointList;
    public List<Transform> startpointHoldList;
    public List<DragableAsset> dragableList;
    public Transform dragableOffScreen;
    private LevelObject currentLevel;

    public void Start()
    {
        DragableStartPoint.SendToGenerator += AddToStartPointList;
        DragableAsset.SendToGenerator += AddToDragableList;
        DragableAsset.ReturnToGenerator += ResetStartPoint;
        StartButton.StartButtonCall += OnRestart;
        RunGame.OnStartLevel += AddCurrentLevel;
    }

    private void AddCurrentLevel(LevelObject obj)
    {
        currentLevel = obj;
    }

    public void OnRestart()
    {
        foreach (Transform point in startpointHoldList)
        {
            startpointList.Add(point);
        }
        startpointHoldList.Clear();
        StartCoroutine(SetDrabables());
    }

    private void ResetStartPoint(Transform startPoint, DragableAsset dragable)
    {
        startpointHoldList.Remove(startPoint);
        startpointList.Add(startPoint);
        dragable.transform.position = dragableOffScreen.position;
        ResetDrabables(dragable);
    }

    private void AddToStartPointList(Transform startPoint)
    {
        startpointList.Add(startPoint);
    }

    private void AddToDragableList(DragableAsset dragable)
    {
        dragableList.Add(dragable);
        dragable.transform.position = dragableOffScreen.position;
    }

    IEnumerator SetDrabables()
    {
        yield return new WaitForSeconds(currentLevel.dragableAppearTime);
        int i = dragableList.Count - 1;
        while (i >= 0)
        {
            yield return new WaitForSeconds(currentLevel.dragableAppearTime);
            ResetDrabables(dragableList[i]);
            i--;
        }
    }

    private void ResetDrabables(DragableAsset dragable)
    {
        int r = UnityEngine.Random.Range(0, startpointList.Count - 1);
        dragable.transform.position = startpointList[r].position;
        dragable.lastStartPoint = startpointList[r];
        startpointHoldList.Add(startpointList[r]);
        startpointList.RemoveAt(r);
    }
}
