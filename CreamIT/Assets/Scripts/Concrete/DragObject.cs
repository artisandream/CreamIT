using UnityEngine;

public class DragObject : MonoBehaviour
{
    Vector3 screenPoint;
    Vector3 offset;
    Vector3 clickPosition;
    Vector3 movePosition;
    
    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void OnMouseDrag()
    {
        clickPosition = Input.mousePosition;
        movePosition = Camera.main.ScreenToWorldPoint(clickPosition) + offset;
        transform.position = movePosition;
    }
}
