using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenPointToRayClick : MonoBehaviour
{
    public static Vector3? GetClickLocation()
    {
        // create a Raycast and set it to the mouses cursor position in game
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            return hit.point;
        }
        else
        {
            return null;
        }
    }

    public static Vector3? GetClickLocation(LayerMask layerMask)
    {
        // create a Raycast and set it to the mouses cursor position in game
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            return hit.point;
        }
        else
        {
            return null;
        }
    }
}
