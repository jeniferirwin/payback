using UnityEngine;

public class HitDisplay : MonoBehaviour
{
    private float ttl;
    void Start()
    {
        ttl = 0.5f;
    }

    void Update()
    {
        ttl -= Time.deltaTime;
        if (ttl <= 0f)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
