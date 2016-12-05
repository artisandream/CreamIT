using UnityEngine;

public class ColorTrigger : MonoBehaviour
{
    public RingAsset ringAsset;
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
            StaticVars.moveSpeed += StaticVars.addSpeed;
        }
    }
}
