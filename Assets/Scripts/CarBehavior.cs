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
    private bool killed;

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
        if (transform.position.y > 50) GameObject.Destroy(gameObject);
        if (killed) return;
        if (hp <= 0) Explode();
        ttl -= Time.deltaTime;
        if (ttl <= 0)
        {
            GameObject.Destroy(gameObject);
        }
    }
    
    private void TurnOffColliders()
    {
        foreach (var coll in GetComponentsInChildren<Collider>())
        {
            coll.enabled = false;
        }
    }
    private void Explode()
    {
        // TODO: play explosion sound
        // TODO: play explosion animation
        killed = true;
        settings.OnCarDestroyed();
        TurnOffColliders();
        var randomZ = Random.Range(-1f, 1f);
        var randomY = Random.Range(-1f, 1f);
        var randomX = Random.Range(-1f, 1f);
        var randomDir = new Vector3(randomX * 5, 1, randomZ * 5);
        rb.constraints = RigidbodyConstraints.None;
        rb.AddForce(randomDir * 10, ForceMode.Impulse);
        var newTorque = new Vector3(randomX, 0, 0);
        rb.AddTorque(newTorque * 5000);
    }
    private void FixedUpdate()
    {
        if (killed) return;
        if (Mathf.Abs(transform.position.z) > 200) GameObject.Destroy(gameObject);
        rb.AddForce(transform.forward * -1 * moveSpeed, ForceMode.Impulse);
    }

    void OnMouseDown()
    {
        if (killed) return;
        TakeDamage();
    }

    private void TakeDamage()
    {
        hp -= 1;
        hpController.SetHP(hp);
        // TODO: play hit sound
    }
}
