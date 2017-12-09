using System;
using Concrete.Rings;
using Static;
using UnityEngine;

namespace Concrete.Color
{
    public class ColorTrigger : MonoBehaviour
    {
        public RingAsset ringAsset;
        public static Action<float> AddSpeedOnTrigger;
        public static Action ColorMatch;
        public static Action ColorNotMatch;

        SpriteRenderer thisRenderer;

        void Start()
        {
            thisRenderer = GetComponent<SpriteRenderer>();
        }
        void OnTriggerEnter(Collider _c)
        {
            if (_c.GetComponent<SpriteRenderer>().material.name ==
                thisRenderer.material.name)
            {
                ringAsset.BlankCenter.material =
                    thisRenderer.material;
                ringAsset.OnSetColor();
                ColorMatch();
            }
            else
            {
                AddSpeedOnTrigger(StaticFunctions.OnModSpeed());
                ColorNotMatch();
            }
        }
    }
}
