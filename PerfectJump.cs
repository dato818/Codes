using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerfectJump : MonoBehaviour
{
       public Vector2 jumpForce;
    [SerializeField]
    private float gravityScale = 1f;
  [SerializeField]
    public float jumpTimer = 0.5f;
    public bool grounded;
 public float jumpTime = 0f;
    public float jumpDelay = 0.5f;
    public float jumpDirection;
private bool pressedJump = false;
    private bool releasedJump = false;
// private bool grounded;
    
    public LayerMask whatIsGround;


     private bool startTimer = false;
    private float timer;
  
          private Collider2D myCollider;


   // public AudioSource jumpSound;

    private Rigidbody2D rb;

    void Start()
    {
         timer = jumpTimer;

    rb = GetComponent<Rigidbody2D>();

        myCollider = GetComponent<Collider2D>();


    }

    // Update is called once per frame
    void Update()
    {
         grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

          if (Input.GetMouseButtonDown(0))
        {
            jumpTime = Time.time + jumpDelay;
    }

    if (Input.GetMouseButtonUp(0))
        {
            releasedJump = true;
        }


        if (startTimer) {
            timer -= Time.deltaTime;
            if (timer <= 0) {
                releasedJump = true;
            }
        }
    }



     private void FixedUpdate() {
        if(jumpTime > Time.time && grounded) {
            pressedJump = true;
           // jumpSound.Play();
        }
     
        

        if (pressedJump) {
            StartJump();
        }

        if (releasedJump) {
            StopJump();
        }
    }


    private void StartJump() {
        rb.gravityScale = 0;
        GetComponent<Rigidbody2D>().AddForce(jumpForce, ForceMode2D.Impulse);
        pressedJump = false;
        startTimer = true;
        jumpTime = 0;
    }

    private void StopJump() {
        rb.gravityScale = gravityScale;
        releasedJump = false;
        timer = jumpTimer;
        startTimer = false;
    }


}
