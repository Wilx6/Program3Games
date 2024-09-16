using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camswitch : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;


    // Start is called before the first frame update
    void Start()
    {
        cam1.SetActive(true);
        cam2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "wack")
        {
            cam1.SetActive (false);
            cam2.SetActive (true);
        }
    }
}
