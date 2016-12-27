using UnityEngine;

public class RingEnd : MonoBehaviour {

	public RingAsset ringAsset;
	
	void OnTriggerEnter()
	{
		GetComponent<CapsuleCollider>().enabled = false;
		ringAsset.OnWin();
	}
}
