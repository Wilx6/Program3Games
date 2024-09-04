using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameMechanic : MonoBehaviour
{
    public List<GameObject> WPlat;
    public List<GameObject> BPlat;

    // Start is called before the first frame update
    void Start()
    {
        BPlat = GameObject.FindGameObjectsWithTag("BGround").ToList<GameObject>();
        WPlat = GameObject.FindGameObjectsWithTag("WGround").ToList<GameObject>();
        foreach (GameObject b in BPlat)
        {
           b.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            foreach (GameObject w in WPlat)
            {
                w.SetActive(false);
            }

            foreach (GameObject b in BPlat)
            {
                b.SetActive(true);
            }
        }
    }
}
