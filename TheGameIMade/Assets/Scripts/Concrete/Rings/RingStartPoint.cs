using System;
using UnityEngine;

namespace Concrete.Rings
{
    public class RingStartPoint : MonoBehaviour
    {

        public static Action<Transform> SendRingStartPoint;

        void Start()
        {
            SendRingStartPoint(transform);
        }

    }
}
