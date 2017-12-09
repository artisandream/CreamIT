using System.Collections;
using System.Collections.Generic;
using Concrete.GameControl;
using Interfaces;
using Static;
using UnityEngine;

namespace Concrete.Rings
{
	public class RingGenerator : MonoBehaviour, IReset {

		private int _ringCount;
		public Transform RignRelocation;
		public List<Transform> RingStartPoints;
		public Transform Destination;
		public List<RingAsset> RingAssetList;
	
		public void Start () {
			RingStartPoint.SendRingStartPoint += SendRingStartPointHandler;
			RingAsset.SendToGenerator += AddToList;
			RunGame.ResetWave += OnReset;
			RunGame.RestartWave += OnRestart;
			RunGame.PlayNextWave += OnRestart;
		}

		private void SendRingStartPointHandler(Transform obj)
		{
			RingStartPoints.Add(obj);
		}

		public void OnReset(bool _bool)
		{
			StopAllCoroutines();
			RingAssetList.Clear();	
		}

		private void AddToList(RingAsset obj)
		{
			RingAssetList.Add(obj);
			obj.transform.position = RignRelocation.position;
		}

		private IEnumerator LaunchRings () {
			while(_ringCount > 0){
				yield return new WaitForSeconds(StaticFunctions.ringGenerateTime);
				RingAssetList[0].transform.position = 
					RingStartPoints[StaticFunctions.RandomNumber(RingStartPoints.Count-1)].position;
				RingAssetList[0].OnSet(Destination);
				RingAssetList.RemoveAt(0);
				_ringCount--;
			}
		}

		public void OnRestart()
		{
			_ringCount = StaticFunctions.currentWave.RingCount;
			StartCoroutine(LaunchRings());
		}
	}
}