using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDirection : MonoBehaviour
{
   public bool moveRight;
    public float playerSpeed;

    private Rigidbody2D rb;


    void Start()
    {
         rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(moveRight){
           
            rb.velocity = new Vector2 (playerSpeed, rb.velocity.y);
        } else {
           
            rb.velocity = new Vector2 (-playerSpeed, rb.velocity.y);
        }

         }


    void OnTriggerEnter2D(Collider2D other){
        if(other.name == "Wall"){
             moveRight = !moveRight;
        }
    }
}
