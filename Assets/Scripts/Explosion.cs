using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    float Bullet_Damage = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy_N")
        {
            Destroy(col.gameObject);
            Debug.Log("Enemy Destroyed by Player");
        }

        if (col.gameObject.tag == "Boss")
        {
            Enemy_Boss enemyboss = GameObject.Find("Boss(Clone)").GetComponent<Enemy_Boss>();
            enemyboss.BossHP -= Bullet_Damage;
            enemyboss.animator.SetTrigger("Damaged");
            Debug.Log("Damaged Enemy");
        }
    }

}
