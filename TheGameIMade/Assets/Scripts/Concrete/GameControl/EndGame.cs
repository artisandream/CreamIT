using System;
using UnityEngine;

namespace Concrete.GameControl
{
	public class EndGame : MonoBehaviour {

		public static Action GameOver;

		void OnTriggerEnter(Collider other)
		{
			GameOver();
		}
	}
}
