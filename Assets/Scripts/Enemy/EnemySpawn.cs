using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawn : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip Siren;

    public GameObject Boss_Approaching_UI;

    public float boss_gen_time = 5f;
    public bool enableSpawn = false;
    public bool bossgen = true;
    public bool boss_defeated = false;    

    public GameObject Enemy;
    public GameObject Enemy2; 
    public GameObject Enemy3; 
    public GameObject Boss;

    public bool pausetime = true;

    public void SpawnEnemy()
    {
        float randomY = Random.Range(-4f, 4f); 
        if (enableSpawn)
        {

            GameObject[] enemy = new GameObject[3];

            for(int i = -1; i < 2; i++)
            {
                enemy[i + 1] = (GameObject)Instantiate(Enemy, new Vector3(10f, randomY+i, 0f), Quaternion.identity);
                enemy[i + 1] = (GameObject)Instantiate(Enemy, new Vector3(10f+1, randomY + i, 0f), Quaternion.identity);
            }
        }       
    }

    public void SpawnEnemy_2() {
        float randomY_2 = Random.Range(-4f, 4f); 
        if (enableSpawn)
        {

            GameObject[] enemy = new GameObject[3];

            for(int i = -1; i < 2; i++)
            {
                enemy[i + 1] = (GameObject)Instantiate(Enemy2, new Vector3(10f, randomY_2+i, 0f), Quaternion.identity);
            }
        }     
    }

    public void SpawnEnemy_3() {
        float randomY_3 = Random.Range(-4f, 4f); 
        if (enableSpawn)
        {
            Instantiate(Enemy3, new Vector3(10f, randomY_3, 0f), Quaternion.identity);
        }     
    }

    void Gen_Boss() {
            if (bossgen == true && SceneManager.GetActiveScene().name == "Stage 3") {
                Instantiate(Boss, new Vector3(0, -8, 0f), Quaternion.identity);
            }
            else if (bossgen == true && SceneManager.GetActiveScene().name == "Stage 4") {
                Instantiate(Boss, new Vector3(7, 0, 0f), Quaternion.identity);
            }
            else {
                Instantiate(Boss, new Vector3(12, 0, 0f), Quaternion.identity);
            }
            bossgen = false;
        }

    void Boss_generation_condition_Checking() {

        if(bossgen == false && pausetime ==  true) {
                enableSpawn = false;
                Boss_Approaching_UI.SetActive(true);
                StartCoroutine(Pause());
                PlaySound("Siren");
        }
    }

    IEnumerator Pause()
    {
        Time.timeScale = 0.001f;
	    yield return new WaitForSecondsRealtime(3f);
        Time.timeScale = 1f;
        Boss_Approaching_UI.SetActive(false);   
        pausetime = false;
    }

    void PlaySound(string Action) {
        switch (Action) {
            case "Siren" :
                audioSource.clip = Siren;
                break;
        }
        audioSource.Play();
    }

    void Start()
    {


        // 쫄소환

        if (SceneManager.GetActiveScene().name == "Prologue") {
            InvokeRepeating("SpawnEnemy", 5, 3); 
            InvokeRepeating("SpawnEnemy_2", 5, 5); 
            InvokeRepeating("SpawnEnemy_3", 30, 30); 
        }

        if (SceneManager.GetActiveScene().name == "Stage 2") {
            InvokeRepeating("SpawnEnemy", 13, 5); 
            InvokeRepeating("SpawnEnemy_2", 5, 30);
            InvokeRepeating("SpawnEnemy_3", 10, 3);              
        }

        if (SceneManager.GetActiveScene().name == "Stage 4") {
            InvokeRepeating("SpawnEnemy", 5, 3); 
            InvokeRepeating("SpawnEnemy_2", 5, 10);
            InvokeRepeating("SpawnEnemy_3", 10, 30);              
        }

        // 보스소환

        Invoke("Gen_Boss", boss_gen_time);

        Boss_Approaching_UI.SetActive(false);
        this.audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        Boss_generation_condition_Checking();
    }

    void InitiatingTimer() {

    }
}