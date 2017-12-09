using System.Collections;
using System.Collections.Generic;
using Concrete.GameControl;
using Static;
using UnityEngine;

namespace Concrete.Dragable
{
    public class DragableGenerator : MonoBehaviour
    {

        public List<Transform> startpointList;
        public List<Transform> startpointHoldList;
        public List<DragableAsset> dragableList;
        public Transform dragableOffScreen;

        public void Start()
        {
            DragableStartPoint.SendToGenerator += AddToStartPointList;
            DragableAsset.SendToGenerator += AddToDragableList;
            DragableAsset.ReturnToGenerator += ResetStartPoint;
            RunGame.RestartWave += OnRestart;
        }

        public void OnRestart()
        {
            foreach (Transform point in startpointHoldList)
            {
                startpointList.Add(point);
            }
            startpointHoldList.Clear();
            StartCoroutine(SetDrabables());
        }

        private void ResetStartPoint(Transform startPoint, DragableAsset dragable)
        {
            startpointHoldList.Remove(startPoint);
            startpointList.Add(startPoint);
            dragable.transform.position = dragableOffScreen.position;
            StartCoroutine(ResetDrabables(dragable));
        }

        private void AddToStartPointList(Transform startPoint)
        {
            startpointList.Add(startPoint);
        }

        private void AddToDragableList(DragableAsset dragable)
        {
            dragableList.Add(dragable);
            //dragable.transform.position = dragableOffScreen.position;
        }

        IEnumerator SetDrabables()
        {
            yield return new WaitForSeconds(StaticFunctions.currentWave.DragableAppearTime);
            int i = dragableList.Count - 1;
            while (i >= 0)
            {
                yield return new WaitForSeconds(StaticFunctions.currentWave.DragableAppearTime);
                StartCoroutine(ResetDrabables(dragableList[i]));
                i--;
            }
        }

        private IEnumerator ResetDrabables(DragableAsset dragable)
        {
            yield return new WaitForSeconds(StaticFunctions.currentWave.DragableAppearTime);
            dragable.RePosition(true);
            int r = StaticFunctions.RandomNumber(startpointList.Count - 1);
            dragable.transform.position = startpointList[r].position;
            dragable.lastStartPoint = startpointList[r];
            startpointHoldList.Add(startpointList[r]);
            startpointList.RemoveAt(r);
        }
    }
}
