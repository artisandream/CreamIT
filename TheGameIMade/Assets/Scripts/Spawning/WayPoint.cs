using System.Reflection;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    public bool IsEndWayPoint;

    public Vector3 GetPosition()
    {
        return gameObject.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D gameObjectHit)
    {
        if (IsEndWayPoint)
        {
            Destroy(gameObjectHit.gameObject);
        }
        else
        {
            var gamePiece = gameObjectHit.GetComponent<EmptyLetterGamePiece>();
            
            if (gamePiece != null)
            {
                gamePiece.MoveNextWayPoint(this);
            }
        }
    }
}
