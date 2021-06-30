using UnityEngine;

public class FrogBehavior : MonoBehaviour
{
    private float moveSpeed;
    private bool isJumper;
    private float jumpCooldown;
    private Animator anim;
    private Rigidbody rb;
    private int frogIntensity;
    
    private void Start()
    {
        frogIntensity = Random.Range(1,4);
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        anim.SetTrigger("Idle");
        moveSpeed = Random.Range(1,4);
        jumpCooldown = GetCooldown();
        if (Random.Range(1,101) <= 50)
        {
            Debug.Log("Creating a jumper");
            isJumper = true;
        }
        else
        {
            Debug.Log("Creating a non-jumper");
            isJumper = false;
        }
    }
    
    private float GetCooldown()
    {
        float min = 0;
        float max = 0;
        switch (frogIntensity)
        {
            case 1:
              min = Random.Range(2f, 3f);
              max = Random.Range(4f, 5f);
              break;
            case 2:
              min = Random.Range(1f, 2f);
              max = Random.Range(3f, 4f);
              break;
            default:
              min = Random.Range(0.5f, 1f);
              max = Random.Range(2f, 3f);
              break;
        }
        return Random.Range(min,max);
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
        if (other.gameObject.CompareTag("Ground") && isJumper)
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
