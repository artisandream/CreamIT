using System;
using System.Collections;
using Concrete.GameControl;
using UnityEngine;

namespace Concrete.Dragable
{
    public class DragableAsset : MonoBehaviour
    {
        public static Action<DragableAsset> SendToGenerator;
        public static Action<Transform, DragableAsset> ReturnToGenerator;
        public Transform lastStartPoint;
        public Transform StartPoint;
        public Transform FirstPoint;
        private Vector3 offset;
        public bool canDrag = true;
        private BoxCollider bc;
        private SpriteRenderer sr;
        private Animator thisAnims;
        private void Start()
        {
            Invoke("StartLate", 0.25f);
            bc = GetComponent<BoxCollider>();
            sr = GetComponent<SpriteRenderer>();
            thisAnims = GetComponent<Animator>();
            OnReset(false);
            RunGame.ResetWave += OnReset;
            RunGame.RestartWave += OnRestart;
            DragableFirstPoint.SendToDragable += OnSetFirstPoint;
        }

        private void OnSetFirstPoint(Transform obj)
        {
            FirstPoint = obj;
        }

        void StartLate()
        {
            SendToGenerator(this);
        }

        public virtual void OnReset(bool _bool)
        {
            thisAnims.SetBool("Reset", _bool);
        }

        private void OnRestart()
        {
            OnReset(false);
        }

        private void OnMouseDown()
        {
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            StartCoroutine(DragAsset());
        }

        private IEnumerator DragAsset()
        {
            while (canDrag)
            {
                yield return new WaitForSeconds(0.01f);
                transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            }
        }

        private void OnMouseUp()
        {
            canDrag = false;
            ReturnToGenerator(lastStartPoint, this);
        }
        private void OnTriggerEnter()
        {
            RePosition(false);
        }

        internal void RePosition(bool _b)
        {
            transform.position = FirstPoint.position;
            bc.enabled = _b;
            sr.enabled = _b;
            canDrag = _b;
        }
    }
}
