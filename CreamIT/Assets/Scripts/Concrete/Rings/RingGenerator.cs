using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RingGenerator : MonoBehaviour, IReset {

	private int ringCount;
	public Transform rignRelocation;
	public List<Transform> RingStartPoints;
	public Transform destination;
	public List<RingAsset> RingAssetList;
	

	public void Start () {
		RingStartPoint.SendRingStartPoint += SendRingStartPointHandler;
		RingAsset.SendToGenerator += AddToList;
		RunGame.OnStartWave += OnStartWaveHandler;
		RunGame.ResetWave += OnReset;
		RunGame.RestartWave += OnRestart;
		RunGame.PlayNextWave += OnRestart;
		ModGame.ModSpeed += ModGeneratorSpeed;
	}

    private void SendRingStartPointHandler(Transform obj)
    {
        RingStartPoints.Add(obj);
    }

    private void ModGeneratorSpeed(float obj)
    {
//        throw new NotImplementedException();
    }

    private void OnStartWaveHandler()
    {
		ringCount = StaticFunctions.currentWave.ringCount;
    }

    public void OnReset()
    {
		StopAllCoroutines();
		RingAssetList.Clear();	
    }

    private void AddToList(RingAsset obj)
    {
        RingAssetList.Add(obj);
		obj.transform.position = rignRelocation.position;
	}

    IEnumerator RecycleRings () {
		while(ringCount > 0){
			yield return new WaitForSeconds(StaticFunctions.currentWave.ringGenerateTime);
			RingAssetList[0].transform.position = 
				RingStartPoints[StaticFunctions.RandomNumber(RingStartPoints.Count-1)].position;
			RingAssetList[0].OnSet(destination);
			RingAssetList.RemoveAt(0);
			ringCount--;
		}
	}

    public void OnRestart()
    {
		ringCount = StaticFunctions.currentWave.ringCount;
        StartCoroutine(RecycleRings());
    }
}