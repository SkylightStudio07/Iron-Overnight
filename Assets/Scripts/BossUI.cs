using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BossUI : MonoBehaviour
{
    Image Charge_Bar;

    // Start is called before the first frame update
    void Start()
    {
        Charge_Bar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        Boss_HP_bar();
    }

    void Boss_HP_bar() 
    {
    EnemySpawn enemyspawn = GameObject.Find("SpawnManager").GetComponent<EnemySpawn>();

    if (enemyspawn.bossgen == false && enemyspawn.boss_defeated == false) {
        Enemy_Boss enemyboss = GameObject.Find("Boss(Clone)").GetComponent<Enemy_Boss>();

	    float Charging_Guage = enemyboss.BossHP; 
	    Charge_Bar.fillAmount = Charging_Guage / 1000;
    }  
}
}