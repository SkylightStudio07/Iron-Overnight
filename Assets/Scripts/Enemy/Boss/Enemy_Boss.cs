using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy_Boss : MonoBehaviour
{

    public Animator animator;
    public GameObject Particle_2;
    public float BossHP = 1000;
    public float maxHP;

    void Start() {
        maxHP = BossHP;
    }

    // Update is called once per frame
    void Update()
    {
        if(BossHP <= 0) {

            EnemySpawn enemyspawn = GameObject.Find("SpawnManager").GetComponent<EnemySpawn>();
            enemyspawn.boss_defeated = true;
            Boss_Clear_Check();
            Instantiate(Particle_2, gameObject.transform.position + new Vector3(0, 0, -1), gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Bullet"))
        {
            animator.SetTrigger("Damaged");
            Destroy(col.gameObject);
        }
    }

    void Boss_Clear_Check() {
        PlayerController playercontroller = GameObject.Find("Square").GetComponent<PlayerController>();
        playercontroller.gameObject.tag = "Player_Ne";

        if (SceneManager.GetActiveScene().name == "Prologue") {
            GameManager.instance.isPrologueCleared = true;
        }
        else if (SceneManager.GetActiveScene().name == "Stage 2") {
            GameManager.instance.isSecondCleared = true;
    }

        else if (SceneManager.GetActiveScene().name == "Stage 3") {
            GameManager.instance.isThirdCleared = true;
    }

        else if (SceneManager.GetActiveScene().name == "Stage 3") {
            LoadingSceneManager.LoadScene("End of the Dream");
    }
}
}
