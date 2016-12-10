using UnityEngine;
public class WaveObject : MonoBehaviour
{
    //Rings
    public int ringCount = 6;
    public float ringGenerateTime = 3f;
    public float ringMoveSpeed = 3.5f;
    public float ringAddSpeed = 0.1f;

    //Dragables
    public float dragableAppearTime = 0.2f;

    //Wave Mods
    public int waveModTimeHold = 5;
    public int waveModCount = 3;
}
