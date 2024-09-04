using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    public float jump;
    public float speed;
    private float Move;

    public bool grounded = true;

    // Start is called before the first frame update
    void Start()
    {


        rb = GetComponent<Rigidbody2D>();


    }
    void Update()
    {

        Move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(Move * speed, rb.velocity.y);

        if (Input.GetKeyDown("space") & grounded == true)
        {
            grounded = false;
            rb.AddForce(new Vector2(rb.velocity.y, jump));
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "WGround")
        {
            grounded= true;
        }

        if (other.gameObject.tag == "BGround")
        {
            grounded = true;
        }
    }
}
