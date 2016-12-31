using System;
using UnityEngine;

public class RingEnd : MonoBehaviour {

	public RingAsset ringAsset;
	private CapsuleCollider cc;

	void Start()
	{
		cc = GetComponent<CapsuleCollider>();
		RunGame.RestartWave += ResetCollider;
	}

    private void ResetCollider()
    {
        cc.enabled = true;
    }

    void OnTriggerEnter()
	{
		cc.enabled = false;
		ringAsset.OnWin();
	}
	
}
