using System;
using Concrete.Color;
using Concrete.GameControl;
using Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace Concrete.Rings
{
    public class RingAsset : MonoBehaviour, IReset
    {

        public static Action<RingAsset> SendToGenerator;
        public static Action RingOnWin;
        public SpriteRenderer BlankCenter;
        public Material Black;
        public GameObject ender;
        public GameObject recycler;
        public Animator thisAnimator;

        private NavMeshAgent thisAgent;
        public void Start()
        {
            thisAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            ColorTrigger.AddSpeedOnTrigger += ResetSpeed;
            RunGame.ResetWave += OnReset;
            RunGame.RestartWave += OnRestart;
            RunGame.SetSpeed += ResetSpeed;
            RunGame.OnModSpeed += ResetSpeed;
        }
        public void OnDestoy ()
        {
            ColorTrigger.AddSpeedOnTrigger -= ResetSpeed;
            RunGame.ResetWave -= OnReset;
            RunGame.RestartWave -= OnRestart;
            RunGame.SetSpeed -= ResetSpeed;
            RunGame.OnModSpeed -= ResetSpeed;
        }

        private void ResetSpeed(float obj)
        {
            thisAgent.speed = obj;
        }

        public void OnSet(Transform destination)
        {
            thisAgent.destination = destination.position;
            thisAgent.Resume();
        }

        public void StopAgent()
        {
            thisAgent.Stop();
        }

        public void OnSetColor()
        {
            ender.SetActive(false);
            recycler.SetActive(true);
        }

        public void OnRestart()
        {
            BlankCenter.material = Black;
            StopAgent();
            SendToGenerator(this);
            ender.SetActive(true);
            recycler.SetActive(false);
            OnReset(false);
        }

        public void OnWin()
        {
            thisAnimator.SetBool("Win", true);
            RingOnWin();
        }

        public void DestroyAsset () {
            //Destroy(gameObject);
        }

        public void OnReset(bool _bool)
        {
            thisAnimator.SetBool("Reset", _bool);
            thisAnimator.SetBool("Win", _bool);
        }
    }
}
