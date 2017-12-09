using UnityEngine;

namespace Concrete.Rings
{
	public class RingRecycle : MonoBehaviour {

		public RingAsset RingAsset;
	
		void OnTriggerEnter()
		{
			RingAsset.OnWin();

		}
	}
}
