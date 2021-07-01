using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour
{
    public LayerMask targetsMask;
    public GameObject hitDisplay;
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray.origin, ray.direction, out hit, 30, targetsMask))
        {
            GameObject.Instantiate(hitDisplay, hit.point, Quaternion.identity);
        }
    }
}
