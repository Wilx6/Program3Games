using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFloor : MonoBehaviour
{
    public float speed;

    public bool Up = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Up == false)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
           

        }
        else if (Up == true)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Top")
        {
            Up = false;
        }

        if (other.tag == "Bottom")
        {
            Up = true;
        }
    }
}
