using UnityEngine;
public class WaveObject : MonoBehaviour
{

    //Rings
    public int ringCount = 20;
    public float ringGenerateTime = 2f;
    public float ringMoveSpeed = 3.5f;
    public float ringAddSpeed = 0.1f;

    //Dragables
    public float dragableAppearTime = 0.2f;

    //Wave Mods
    public int levelModTimeHold = 3;
    public int levelModCount = 3;
}
