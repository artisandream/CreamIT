using UnityEngine;
using System.Collections;

public class DragObject : MonoBehaviour
{
    Vector3 mousePosition;
    void OnMouseDrag()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition;
    }
}
