using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRemove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Enemy")
        {
            Destroy(col.gameObject);
            Debug.Log("Bullet Destroyed");
        }
        if (col.gameObject.tag == "Bullet")
        {
            Destroy(col.gameObject);
            Debug.Log("Bullet Destroyed");
        }

        if (col.gameObject.tag == "Enemy_Bullet")
        {
            Destroy(col.gameObject);
            Debug.Log("Bullet Destroyed");
        }

        else if (col.gameObject.tag == "Enemy_N")
        {
            Destroy(col.gameObject);
            Debug.Log("Enemy Destroyed");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
