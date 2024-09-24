using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{

    public Transform orientation;
    public Transform player;
    public Transform playerObj;
    public Rigidbody rbl;

    public float rotationSpeed;
     
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, player.position.z);
        orientation.forward = viewDir.normalized;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (inputDir != Vector3.zero)
        {
            orientation.forward = viewDir.normalized;
            player.forward = Vector3.Slerp(player.forward, inputDir.normalized.normalized, Time.deltaTime * rotationSpeed);
        }
    }
}
