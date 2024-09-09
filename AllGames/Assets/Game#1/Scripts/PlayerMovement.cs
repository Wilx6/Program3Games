using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    GameMechanic gm;
    [SerializeField] GameObject BOF;

    private Rigidbody2D rb;
    public float jump;
    public float speed;
    private float Move;

    public bool grounded = true;

    private Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        gm = BOF.GetComponent<GameMechanic>();

        rend = GetComponent<Renderer>();

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

        if (gm.BOnOff == true)
        {
            rend.material.color = Color.black;
        }

        if (gm.BOnOff == false)
        {
            rend.material.color = Color.white;
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
        
        if (other.gameObject.tag == "Safe")
        {
            grounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Death1")
        {
            SceneManager.LoadScene(1);
        }

        if (other.tag == "Death2")
        {
            SceneManager.LoadScene(2);
        }

        if (other.tag == "Death3")
        {
            SceneManager.LoadScene(3);
        }

        if (other.tag == "Win1")
        {
            SceneManager.LoadScene(2);
        }

        if (other.tag == "Win2")
        {
            SceneManager.LoadScene(3);
        }

        if (other.tag == "End")
        {
            SceneManager.LoadScene(4);
        }
    }
}
