using UnityEngine;

public class ColorTrigger : MonoBehaviour
{
    public SpriteRenderer center;

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
            center.material = thisRenderer.material;
        }
    }
}
    