using UnityEngine;

public class MouseSpotlight : MonoBehaviour
{
    public GameObject spotlight;
    public LayerMask groundMask;
    private Vector2 mousePos;

    void FixedUpdate()
    {
        mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
        Debug.Log($"{mousePos}");
        Debug.Log($"{Input.mousePosition}");
        transform.LookAt(new Vector3(mousePos.x, 0, mousePos.y));
    }
}
