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
            Debug.Log("OnTriggerEnter2D");
            var gamePiece = gameObjectHit.GetComponent<GamePiece>();
            gamePiece.MoveNextWayPoint();
        }
    }
}
