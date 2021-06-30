using UnityEngine;

public class FrogBehavior : MonoBehaviour
{
    private float moveSpeed;
    private bool isJumper;
    private float jumpCooldown;
    private Animator anim;
    private Rigidbody rb;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        anim.SetTrigger("Idle");
        moveSpeed = Random.Range(1,8);
        jumpCooldown = 1;
        if (Random.Range(1,49) <= 50)
            isJumper = true;
        else
            isJumper = false;
    }

    private void FixedUpdate()
    {
        jumpCooldown -= Time.fixedDeltaTime;
        if (isJumper && jumpCooldown <= 0)
        {
            jumpCooldown = Random.Range(1, 3f);
            Jump();
        }
        else if (!isJumper)
        {
            anim.SetTrigger("Crawl");
            var speed = Vector3.forward * moveSpeed * Time.fixedDeltaTime;
            transform.Translate(speed);
        }
    }
    
    private void Jump()
    {
        anim.SetTrigger("Jump");
        var force = transform.forward * Random.Range(100f, 175f);
        rb.AddForce(force, ForceMode.Impulse);
    }
}
