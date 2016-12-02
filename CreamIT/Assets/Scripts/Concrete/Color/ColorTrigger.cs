using UnityEngine;

public class ColorTrigger : MonoBehaviour
{
    public SpriteRenderer center;
    public GameObject ender;
    public GameObject recycler;
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
            ender.SetActive(false);
            recycler.SetActive(true);
        } else {
            StaticVars.moveSpeed += StaticVars.addSpeed;
        }
    }
}
    