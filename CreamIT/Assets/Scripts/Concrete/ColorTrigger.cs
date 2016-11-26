using UnityEngine;

public class ColorTrigger : MonoBehaviour
{

    void OnTriggerEnter(Collider _c)
    {
        if (_c.GetComponent<SpriteRenderer>().material.name ==
            GetComponent<SpriteRenderer>().material.name)
        {
            print(_c.GetComponent<SpriteRenderer>().material.name);
        }
    }
}
