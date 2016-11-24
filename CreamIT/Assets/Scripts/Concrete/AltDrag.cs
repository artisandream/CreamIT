using UnityEngine;
public class AltDrag : MonoBehaviour
{
    Vector3 mousePosition;
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            mousePosition.z = 0;
        	transform.position = mousePosition;
        }
    }
}
