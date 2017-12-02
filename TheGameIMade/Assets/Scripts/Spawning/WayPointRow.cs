using UnityEngine;
using UnityEngine.Events;

public class WayPointRow : MonoBehaviour
{
	public static UnityAction<WayPointRow> WayPointRowAdded;
	private WayPoint[] _wayPoints;
	
	private void Start()
	{
		_wayPoints = GetComponentsInChildren<WayPoint>();
		
		if (WayPointRowAdded != null)
		{
			WayPointRowAdded.Invoke(this);
		}
	}

	public WayPoint GetRandomWayPoint()
	{
		var randomIndex = Random.Range(0, _wayPoints.Length);
		return _wayPoints[randomIndex];
	}
}
