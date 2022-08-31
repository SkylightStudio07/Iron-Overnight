using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType1 : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * 0.05f);
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
    }

}
