using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Boss : MonoBehaviour
{

    public Animator animator;

    public float BossHP = 1000;


    // Update is called once per frame
    void Update()
    {
        if(BossHP <= 0) {
            EnemySpawn enemyspawn = GameObject.Find("SpawnManager").GetComponent<EnemySpawn>();
            enemyspawn.boss_defeated = true;
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Bullet"))
        {
            animator.SetTrigger("Damaged");
        }
    }
}
