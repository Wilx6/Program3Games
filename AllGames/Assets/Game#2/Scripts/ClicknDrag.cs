using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClicknDrag : MonoBehaviour
{

    Vector3 mousePostiton;

    private Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);

    }

    private void OnMouseDown()
    {
        
        mousePostiton = Input.mousePosition - GetMousePos();

    }

    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePostiton);
    }

}
