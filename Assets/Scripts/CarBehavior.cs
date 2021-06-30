using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehavior : MonoBehaviour
{
    private float moveSpeed;
    private float hp;
    private Rigidbody rb;
    private float ttl;

    private void Awake()
    {
        moveSpeed = Random.Range(0.3f, 0.5f);
        hp = Random.Range(1f, 4f);
        rb = GetComponent<Rigidbody>();
        ttl = 30f;
    }
    
    private void Update()
    {
        if (hp <= 0) Explode();
        ttl -= Time.deltaTime;
        if (ttl <= 0)
        {
            GameObject.Destroy(gameObject);
        }
    }
    
    private void Explode()
    {
        // TODO: play explosion sound
        // TODO: play explosion animation
        GameObject.Destroy(gameObject);
        GameObject.Destroy(this);
    }
    private void FixedUpdate()
    {
        if (Mathf.Abs(transform.position.z) > 200) GameObject.Destroy(gameObject);
        rb.AddForce(transform.forward * -1 * moveSpeed, ForceMode.Impulse);
    }

    void OnMouseDown()
    {
        TakeDamage();
    }

    private void TakeDamage()
    {
        hp -= 1;
        Debug.Log($"Took damage!");
        // TODO: play hit sound
    }
}
