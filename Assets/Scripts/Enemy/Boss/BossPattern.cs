using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPattern : MonoBehaviour
{

    public float boss_speed = 0.01f;

    public GameObject PlayerPos;

    public GameObject Boss_Prologue_Charging;
    public GameObject Boss_Prologue_Laser;
    public GameObject Boss_Prologue_Torpedo;
    public GameObject Boss_Prologue_Carrierborne_Aircrafts;
    public Transform Boss_FirePos;

    public bool Boss_Prologue_isDelay = true;
    public bool Boss_Prologue_Charging_Check = true;
    public bool Boss_Prologue_Laser_check = true;
    
    public Transform LaserPos;

    void Prologue_Boss_Pattern_Manager() {
        float randomY = Random.Range(-200f, 200f);
        if (Boss_Prologue_isDelay == true && Boss_Prologue_Charging_Check == true) {

            GameObject myCharging = Instantiate(Boss_Prologue_Charging, Boss_FirePos.transform.position, Boss_FirePos.transform.rotation);
            myCharging.transform.SetParent(this.transform);
            Boss_Prologue_Charging_Check = false;            
            StartCoroutine(Pattern1());        
        }
    }

    void Boss_Move() {
        transform.Translate(new Vector3(0, PlayerPos.transform.position.y - gameObject.transform.position.y + 1.8f, 0) * Time.deltaTime * boss_speed);
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

        viewPos.y = Mathf.Clamp01(viewPos.y);

        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
        transform.position = worldPos;
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerPos = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Prologue_Boss_Pattern_Manager();
        Boss_Move();                
    }

    IEnumerator Pattern1() {
        yield return new WaitForSeconds(3.0f);
        if(Boss_Prologue_Laser_check == true) {
            GameObject myLaser = Instantiate(Boss_Prologue_Laser, Boss_FirePos.transform.position + new Vector3(-9f, 0, 0), Boss_FirePos.transform.rotation);
            myLaser.transform.SetParent(this.transform);
        }
        Boss_Prologue_Laser_check = false;
        yield return new WaitForSeconds(3.0f);

        for(int i = 0; i<4; i++) {
            Instantiate(Boss_Prologue_Torpedo, Boss_FirePos.transform.position, Boss_FirePos.transform.rotation);
            yield return new WaitForSeconds(0.5f);
        }
        yield return new WaitForSeconds(4.0f);
        Spawn_Boss_Prologue_Carrierborne_Aircrafts();
        yield return new WaitForSeconds(3.0f);       

        Boss_Prologue_Laser_check = true;
        Boss_Prologue_Charging_Check = true;   
    }

    void Spawn_Boss_Prologue_Carrierborne_Aircrafts() {
        float randomY = Random.Range(-4f, 4f); 
            GameObject[] enemy = new GameObject[3];
            for(int i = -1; i < 2; i++)
            {
                enemy[i + 1] = (GameObject)Instantiate(Boss_Prologue_Carrierborne_Aircrafts, new Vector3(10f, randomY+i, 0f), Quaternion.identity);
            }
        }    
    }

