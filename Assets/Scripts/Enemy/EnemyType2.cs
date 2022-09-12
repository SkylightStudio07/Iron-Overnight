using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType2 : MonoBehaviour
{

    public GameObject Enemy_Bullet;
    public Transform FirePos;

    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0, 0, -90);
        StartCoroutine(Enemy2_Move());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * 0.001f);
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

    IEnumerator Enemy2_Move() {
        transform.Translate(Vector3.left * 0.01f);
        yield return new WaitForSeconds(2f);
        Instantiate(Enemy_Bullet, FirePos.transform.position, FirePos.transform.rotation);
        transform.Translate(Vector3.left * 0.01f); 
        yield return new WaitForSeconds(2f);
    }    

}
