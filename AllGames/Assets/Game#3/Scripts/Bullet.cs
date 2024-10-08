using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float lifeTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;

        if(lifeTime < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(DestroySpeedBuild());
    }

    IEnumerator DestroySpeedBuild()
    {
        yield return new WaitForSeconds(.5f);
        Destroy(this.gameObject);
    }
}
