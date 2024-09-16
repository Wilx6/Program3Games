using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forceee : MonoBehaviour
{
    Rigidbody rb;
    public float forceleft;
    public float forceup;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "hand")
        {
            rb.AddForce(new Vector3(-forceleft, forceup, 0f), ForceMode.Force);
        }
    }
}
