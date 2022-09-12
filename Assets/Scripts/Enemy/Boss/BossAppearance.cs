using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAppearance : MonoBehaviour
{

    public GameObject Boss_Name_UI;
    public GameObject Boss_Portrait_UI;
    public GameObject Boss_Unknown_Portrait_UI;
    public GameObject Victory;

    // Start is called before the first frame update
    void Start()
    {
        Boss_Name_UI.SetActive(false);
        Boss_Portrait_UI.SetActive(false);
        Boss_Unknown_Portrait_UI.SetActive(true);
    }

    void Boss_Reveal() {
        EnemySpawn enemyspawn = GameObject.Find("SpawnManager").GetComponent<EnemySpawn>();

        if (enemyspawn.bossgen == false) {
        Boss_Name_UI.SetActive(true);
        Boss_Portrait_UI.SetActive(true);
        Boss_Unknown_Portrait_UI.SetActive(false);            
        }

        // 여기서부터는 승리 UI 관제

        if (enemyspawn.boss_defeated == true) {
            Victory.SetActive(true);
            GameManager.instance.isMove = false;
            StartCoroutine(GameManager.instance.END_Stage());
        }
    }

    // Update is called once per frame
    void Update()
    {
        Boss_Reveal();
    }
}
