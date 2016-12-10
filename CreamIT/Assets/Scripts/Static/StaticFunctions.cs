using UnityEngine;

public class StaticFunctions : MonoBehaviour
{

    public static WaveObject currentWave;
    public static float currentSpeed;
    public static float ringGenerateTime;
	public static int addedRingCount;
	
    public static int RandomNumber(int _totalAvaliable)
    {
        return Random.Range(0, _totalAvaliable);
    }

    public static float SetGenTime(float newTime)
    {
        return ringGenerateTime = newTime;
    }

    public static float ChangeGenTime()
    {
        if (ringGenerateTime > 0.1f)
        {
            return ringGenerateTime -= currentWave.ringAddSpeed;
        }
        else
        {
            return 0.1f;
        }

    }
    public static float SetSpeed()
    {
        return currentSpeed = currentWave.ringMoveSpeed;
    }
	
    public static float OnModSpeed()
    {
        return currentSpeed += currentWave.ringAddSpeed;
    }
}
