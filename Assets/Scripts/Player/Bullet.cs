using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject Particle_1;

    void Update()
    {
        transform.Translate(Vector3.right * 0.04f);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Instantiate(Particle_1, gameObject.transform.position + new Vector3(0, 0, -1), gameObject.transform.rotation);
        }

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
            enemyboss.BossHP -= GameManager.instance.Bullet_Damage;

            enemyboss.animator.SetTrigger("Damaged");
            Debug.Log("Damaged Enemy");

            if (GameManager.instance.normal_particle_num < 8) {
                GameManager.instance.normal_particle_num++;
                Instantiate(Particle_1, gameObject.transform.position + new Vector3(0, 0, -1), gameObject.transform.rotation);
            }
            Destroy(gameObject);
        }
    }

}