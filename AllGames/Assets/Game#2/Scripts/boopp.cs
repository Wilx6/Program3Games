using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boopp : MonoBehaviour
{
    public Vector3 myPos;
    public Transform myPlay;

    public void Update()
    {
        transform.position = myPlay.position + myPos;

        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(1);
        }
    }

}
