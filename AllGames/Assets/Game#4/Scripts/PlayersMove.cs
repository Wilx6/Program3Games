using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayersMove : MonoBehaviour
{

    public GameObject bullettt;

    public GameObject PLAYER;
    public bool Fast = false;
    public bool Strong = false;
    public bool Shoot = false;



    public Camera playerCamera;
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpPower = 7f;
    public float gravity = 10f;
    public float lookSpeed = 2f;
    public float lookXLimit = 45f;

    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;
    private CharacterController characterController;

    private bool canMove = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        bullettt.SetActive(false);
    }

    void Update()
    {

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        Renderer playerRenderer = PLAYER.GetComponent<Renderer>();

        if (other.gameObject.tag == "BluePill")
        {
            PLAYER.transform.localScale = new Vector3(.5f, .5f, .5f);
            walkSpeed = 40f;
            runSpeed = 100f;
            Destroy(other.gameObject);
            Destroy(GameObject.FindWithTag("RedPill"));
            Destroy(GameObject.FindWithTag("YellowPill"));
            playerRenderer.material.color = Color.blue;
            Fast = true;

        }
        
        if (other.gameObject.tag == "RedPill")
        {
            PLAYER.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            walkSpeed = 5f;
            runSpeed = 10f;
            Destroy(other.gameObject);
            Destroy(GameObject.FindWithTag("BluePill"));
            Destroy(GameObject.FindWithTag("YellowPill"));
            playerRenderer.material.color = Color.red;
            Strong = true;
            
        }

        if (other.gameObject.tag == "YellowPill")
        {
            
            Destroy(other.gameObject);
            Destroy(GameObject.FindWithTag("BluePill"));
            Destroy(GameObject.FindWithTag("RedPill"));
            playerRenderer.material.color = Color.yellow;
            bullettt.SetActive(true);
            Shoot = true;

        }

    }

}
