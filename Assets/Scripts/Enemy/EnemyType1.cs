using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType1 : MonoBehaviour
{

    public GameObject Particle_1;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * 0.008f);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("AutoRemoveSection"))
        {
            Destroy(gameObject);
        }
        if (col.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "Ally")
        {
            Destroy(col.gameObject);
            
            Instantiate(Particle_1, gameObject.transform.position + new Vector3(0, 0, -1), gameObject.transform.rotation);
            Destroy(gameObject);
        }     
    }

}
