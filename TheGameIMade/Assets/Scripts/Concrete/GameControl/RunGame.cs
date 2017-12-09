using System;
using System.Collections;
using System.Collections.Generic;
using Concrete.GUI;
using Static;
using UnityEngine;

namespace Concrete.GameControl
{
    public class RunGame : MonoBehaviour
    {
        public static Action OnStartWave;
        public static Action<float> SetSpeed;
        public List<WaveObject> WaveObjectList;
        public static Action<float> OnModSpeed;
        public static Action<bool> ResetWave;
        public static Action RestartWave;
        public static Action PlayNextWave;
        private int _nextWaveNum = 0;

        public float NewSpeed;
        public float NewGenTime;
        public float ModNum;

        public void Start()
        {
            StartButton.StartButtonCall += OnStartButton;
            Invoke("CheckWave", 0.01f);
            NextWave.GoToNextWave += StartModGame;
            NextWave.GoToNextWave += GoToNextWaveHandler;
            NextWave.OnWinGame += WinGame;
            EndGame.GameOver += OnReset;
        }

        private void WinGame()
        {
            print("Win");
        }

        private void AddToWaveObjectList(WaveObject obj)
        {
            WaveObjectList.Add(obj);
        }

        private void OnStartButton()
        {
            _nextWaveNum = 0;
            OnRestart(RestartWave);
        }

        private void GoToNextWaveHandler()
        {
            if (_nextWaveNum < WaveObjectList.Count - 1)
            {
                _nextWaveNum++;
                OnRestart(PlayNextWave);
            }
            else
            {
                _nextWaveNum = 0;
                NextWave.GoToNextWave -= GoToNextWaveHandler;
            }

        }

        public void OnReset()
        {
            ResetWave(true);
            StaticFunctions.addedRingCount = 0;
        }

        public void OnRestart(Action sendAction)
        {
            CheckWave();
            SetSpeed(StaticFunctions.SetSpeed());
            StaticFunctions.SetGenTime(StaticFunctions.currentWave.RingGenerateTime);
            OnStartWave();
            StartModGame();
            sendAction();
        }

        private void CheckWave()
        {
            StaticFunctions.currentWave = WaveObjectList[_nextWaveNum];
        }

        private void StartModGame()
        {
            StartCoroutine(ModSpeed());
        }

        private IEnumerator ModSpeed()
        {
            StaticFunctions.addedRingCount++;
            NewSpeed = StaticFunctions.currentWave.RingMoveSpeed;
            ModNum = StaticFunctions.currentWave.WaveModCount;
            while (ModNum > 0)
            {
                yield return new WaitForSeconds(StaticFunctions.currentWave.WaveModTimeHold);
                NewSpeed = StaticFunctions.OnModSpeed();
                NewGenTime = StaticFunctions.currentWave.RingGenerateTime;
                StaticFunctions.ChangeGenTime();
                ModNum--;
                OnModSpeed(NewSpeed);
            }
        }
    }
}
