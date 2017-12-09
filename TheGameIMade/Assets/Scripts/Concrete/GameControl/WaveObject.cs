using System;
using UnityEngine;

namespace Concrete.GameControl
{
    public class WaveObject : MonoBehaviour
    {
        public static Action<int> RingCountAction;
        //public static Action<WaveObject> SendWave;
        void Start()
        {
            RingCountAction(RingCount);
            //SendWave(this);
        }
        //Rings
        public int RingCount = 6;
        public float RingGenerateTime = 3f;
        public float RingMoveSpeed = 3.5f;
        public float RingAddSpeed = 0.1f;

        //Dragables
        public float DragableAppearTime = 0.2f;

        //Wave Mods
        public int WaveModTimeHold = 5;
        public int WaveModCount = 3;
    }
}
