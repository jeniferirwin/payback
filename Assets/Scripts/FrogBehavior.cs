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
        jumpCooldown = Random.Range(2f, 5.5f);
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
            jumpCooldown = Random.Range(1, 5f);
            Jump();
        }
        else if (!isJumper)
        {
            anim.SetTrigger("Crawl");
            var speed = Vector3.forward * moveSpeed * Time.fixedDeltaTime;
            transform.Translate(speed);
        }
    }
    
    /*
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Jumped");
        }
    }
    */
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            //anim.ResetTrigger("Jump");
            anim.SetTrigger("Idle");
        }
    }
    private void Jump()
    {
        anim.ResetTrigger("Idle");
        anim.SetTrigger("Jump");
        var force = (transform.forward + transform.up) * Random.Range(50f, 100f);
        rb.AddForce(force, ForceMode.Impulse);
    }
}
