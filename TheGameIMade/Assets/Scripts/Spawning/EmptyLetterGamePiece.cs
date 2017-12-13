using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EmptyLetterGamePiece : GamePiece
{
    [SerializeField] private float _speed = 10.0f;
    private int _currentWayPoint = 0;
    private List<WayPoint> _wayPoints = new List<WayPoint>();

    public void AddWayPoint(WayPoint newWayPoint)
    {
        _wayPoints.Add(newWayPoint);
    }

    public void MoveToFirstWayPoint()
    {
        _currentWayPoint = 0;
        MoveNext();
    }

    public void MoveNextWayPoint(WayPoint wayPointHit)
    {
        if (_currentWayPoint >= _wayPoints.Count  || !_wayPoints.Contains(wayPointHit))
        {
            return;
        }
        
        MoveNext();
    }

    private void MoveNext()
    {
        gameObject.transform.DOMove(_wayPoints[_currentWayPoint].GetPosition(), _speed);
        _currentWayPoint++;
    }

    private void OnTriggerEnter2D(Collider2D otherLetter)
    {
        Debug.Log("OnCollisionEnter2D " + this.gameObject.name);
        var letterScript = otherLetter.gameObject.GetComponent<LetterGamePiece>();

        if (letterScript == null || letterScript.IsMatched)
        {
            return;
        }

        letterScript.LastCollidedEmptyPiece = this;
    }

    private void OnTriggerExit2D(Collider2D otherLetter)
    {
        Debug.Log("OnCollisionExit2D " + this.gameObject.name);

        var letterScript = otherLetter.gameObject.GetComponent<LetterGamePiece>();

        if (letterScript == null || letterScript.IsMatched)
        {
            return;
        }

        letterScript.LastCollidedEmptyPiece = null;
    }
}