using UnityEngine;

public class RingEnd : MonoBehaviour {

	public RingAsset ringAsset;
	
	void OnTriggerEnter()
	{
		ringAsset.OnWin();
	}
}
