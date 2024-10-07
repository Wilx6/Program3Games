using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildings : MonoBehaviour
{

    public float launchForce;
    public float launchRotation;
   

    public GameObject BUILDS;
    

    PlayersMove Powers;
    [SerializeField] GameObject Player;
    
    // Start is called before the first frame update
    void Awake()
    {
        Powers = Player.GetComponent<PlayersMove>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        Renderer playerRenderer = BUILDS.GetComponent<Renderer>();

        if (other.gameObject.tag == "Player" && Powers.Fast == true)
        {
            playerRenderer.material.color = Color.black;
            StartCoroutine(DestroySpeedBuild());
        }

        if (other.gameObject.tag == "Player" && Powers.Strong == true)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            Vector3 direction = (transform.position - other.transform.position).normalized;

            rb.AddForce(direction * launchForce);

            Vector3 rotationDirection = Vector3.Cross(direction, Vector3.up).normalized;
            rb.AddTorque(-rotationDirection * launchRotation);
            StartCoroutine(DestroyStrongBuild());
        }

        if (other.gameObject.tag == "WorldObjectHolder" && Powers.Shoot == true)
        {
            playerRenderer.material.color = Color.red;
            StartCoroutine(DestroySpeedBuild());
        }
    }

    IEnumerator DestroySpeedBuild()
    {
        yield return new WaitForSeconds(.5f);
        Destroy(this.gameObject);
    }

    IEnumerator DestroyStrongBuild()
    {
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }
}
