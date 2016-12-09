using UnityEngine;

public class StaticFunctions: MonoBehaviour{

	public static WaveObject currentWave;
	public static float currentSpeed;
	public static float ringGenerateTime;
	public static int RandomNumber (int _totalAvaliable) {
		return Random.Range(0, _totalAvaliable);
	}

	public static float SetGenTime (float newTime) {
		return ringGenerateTime = newTime;
	}

	public static float ChangeGenTime (float newTime) {
		return ringGenerateTime - newTime;
	}
	public static float SetSpeed (float newSpeed) {
		return currentSpeed = newSpeed;
	}
	public static float ChangeSpeed (float addedSpeed) {
		return currentSpeed += addedSpeed;
	}
}
