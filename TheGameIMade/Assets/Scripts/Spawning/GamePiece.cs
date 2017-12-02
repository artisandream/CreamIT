using System.Collections.Generic;
//using DG.Tweening;
using UnityEngine;

public class GamePiece : MonoBehaviour
{
    [SerializeField] private float _speed = 2.0f;
    private int _currentWayPoint = 0;
    private List<WayPoint> _wayPoints = new List<WayPoint>();

    public void AddWayPoint(WayPoint newWayPoint)
    {
        _wayPoints.Add(newWayPoint);
    }

    public void MoveNextWayPoint()
    {
        //TODO: Fix so piece can only hit one way point per row
        //TODO: For now added skip
        if (_currentWayPoint >= _wayPoints.Count)
        {
            return;
        }

        //gameObject.transform.DOMove(_wayPoints[_currentWayPoint].GetPosition(), _speed);
        _currentWayPoint++;
    }
}