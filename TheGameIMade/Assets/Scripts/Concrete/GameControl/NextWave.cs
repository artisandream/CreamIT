using System;
using Static;
using UnityEngine;

namespace Concrete.GameControl
{
    public class NextWave : MonoBehaviour
    {

        public static Action GoToNextWave;
        public static Action OnWinGame;
        public int ringCount;

        void Start()
        {
            RunGame.OnStartWave += OnStartWaveHandler;
        }

        private void OnStartWaveHandler()
        {
            ringCount = StaticFunctions.currentWave.RingCount;
        }

        void OnTriggerEnter(Collider other)
        {
            ringCount--;
            StaticFunctions.totalRingCount--;
            if (StaticFunctions.totalRingCount == 0)
            {
                OnWinGame();
            }

            if (ringCount == 0)
            {
                if (GoToNextWave != null)
                {
                    GoToNextWave();
                }

            }
        }
    }
}
