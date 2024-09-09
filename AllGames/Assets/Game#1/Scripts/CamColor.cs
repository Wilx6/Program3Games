using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamColor : MonoBehaviour
{

    GameMechanic gm;
    [SerializeField] GameObject BOF;

    [SerializeField]
    private Color colorToTurnTo = Color.white;

    // Start is called before the first frame update
    void Start()
    {
        gm = BOF.GetComponent<GameMechanic>();

    }

    // Update is called once per frame
    void Update()
    {
        if (gm.BOnOff == true)
        {
            Camera.main.backgroundColor = Color.white;
        }

        if (gm.BOnOff == false)
        {
            Camera.main.backgroundColor = Color.black;
        }
    }
}
