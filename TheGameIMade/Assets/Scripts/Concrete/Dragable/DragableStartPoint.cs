using System;
using UnityEngine;

namespace Concrete.Dragable
{
	public class DragableStartPoint : MonoBehaviour {

		public static Action<Transform> SendToGenerator;

		public void OnRestart()
		{
			SendToGenerator(transform);
		}

		public void Start () {
			SendToGenerator(transform);
		}
	
	}
}
