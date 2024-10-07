using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoott : MonoBehaviour
{

    public float bulletSpeed;
    public float fireRate;
    public bool isAuto;

    public Transform bulletSpawnTransform;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isAuto)
        {
            if (Input.GetButton("Fire1"))
            {

            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnTransform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("WorldObjectHolder").transform);
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawnTransform.forward * bulletSpeed, ForceMode.Impulse);
    }
}
