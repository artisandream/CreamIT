using UnityEngine;

namespace Spawning
{
	public class WayPointController : MonoBehaviour
	{
		public int NumberOfRows = 3;
		public GameObject WayPointRowPrefab;

		private void Awake()
		{
			for (var i = 0; i < NumberOfRows; i++)
			{
				Instantiate(WayPointRowPrefab, transform);
			}
		}
	}
}