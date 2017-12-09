using System;
using UnityEngine;

namespace Concrete.Dragable
{
	public class DragableFirstPoint : MonoBehaviour {

		public static Action<Transform> SendToDragable;

		public void Start () {	
			SendToDragable(transform);
		}
	}
}
