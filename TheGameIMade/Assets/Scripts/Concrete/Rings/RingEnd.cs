using Concrete.GameControl;
using UnityEngine;

namespace Concrete.Rings
{
	public class RingEnd : MonoBehaviour {

		public RingAsset RingAsset;
		private CapsuleCollider _cc;

		void Start()
		{
			_cc = GetComponent<CapsuleCollider>();
			RunGame.RestartWave += ResetCollider;
		}

		private void ResetCollider()
		{
			_cc.enabled = true;
		}

		void OnTriggerEnter()
		{
			_cc.enabled = false;
			RingAsset.OnWin();
		}
	
	}
}
