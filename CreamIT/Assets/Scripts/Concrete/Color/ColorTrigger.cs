using UnityEngine;
using System;
public class ColorTrigger : MonoBehaviour
{
    public RingAsset ringAsset;
    public static Action<float> AddSpeedOnTrigger;
        public float AddedSpeed = 0.1f;

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
            ringAsset.blankCenter.material = thisRenderer.material;
            ringAsset.OnSetColor();
        }
        else
        {
            AddSpeedOnTrigger(AddedSpeed);
        }
    }
}
