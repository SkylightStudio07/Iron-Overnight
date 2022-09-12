using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType5 : MonoBehaviour
{

    public float hp = 120;
    public GameObject PlayerPos;


    // Start is called before the first frame update
    void Start()
    {
        PlayerPos = GameObject.FindGameObjectWithTag("Player");
        transform.position = new Vector2(transform.position.x, PlayerPos.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * 0.007f);
        if (hp < 0) {
            Destroy(gameObject);
        }

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("AutoRemoveSection"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    
    {
        if (col.gameObject.CompareTag("Bullet"))
        {
            hp -= GameManager.instance.Bullet_Damage;
            Destroy(col.gameObject);
        }
    }

}
