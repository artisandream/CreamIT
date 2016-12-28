using UnityEngine;

public class RingRecycle : MonoBehaviour {

	public RingAsset ringAsset;
	
	void OnTriggerEnter()
	{
		ringAsset.OnWin();

	}
}
