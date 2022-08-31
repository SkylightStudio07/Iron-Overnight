using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float Bullet_Damage = 10;
    public GameObject Particle_1;

    void Update()
    {
        transform.Translate(Vector3.right * 0.1f);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy_N")
        {
            Destroy(col.gameObject);
            Debug.Log("Enemy Destroyed by Player");
            Instantiate(Particle_1, gameObject.transform.position + new Vector3(0, 0, -1), gameObject.transform.rotation);
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Boss")
        {
            Enemy_Boss enemyboss = GameObject.Find("Boss(Clone)").GetComponent<Enemy_Boss>();
            enemyboss.BossHP -= Bullet_Damage;
            enemyboss.animator.SetTrigger("Damaged");
            Debug.Log("Damaged Enemy");
            Instantiate(Particle_1, gameObject.transform.position + new Vector3(0, 0, -1), gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }

}