using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehavior : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField] private HPController hpController;
    private float moveSpeed;
    private Rigidbody rb;
    private Settings settings;
    private float ttl;

    private void Start()
    {
        settings = GameObject.FindGameObjectWithTag("Settings").GetComponent<Settings>();
        moveSpeed = Random.Range(0.3f, 0.5f);
        rb = GetComponent<Rigidbody>();
        ttl = 30f;
        hpController.SetHP(hp);
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
        settings.OnCarDestroyed();
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
        hpController.SetHP(hp);
        // TODO: play hit sound
    }
}
