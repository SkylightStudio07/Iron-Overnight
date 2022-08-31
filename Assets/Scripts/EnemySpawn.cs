using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip Siren;

    public GameObject Boss_Approaching_UI;

    public float boss_gen_time_check;
    public float boss_gen_time = 5f;
    public bool enableSpawn = false;
    public bool bossgen = true;
    public bool boss_defeated = false;    

    public GameObject Enemy; //Prefab�� ���� public ���� �Դϴ�.
    public GameObject Boss;

    public bool pausetime = true;

    void SpawnEnemy()
    {
        float randomY = Random.Range(-4f, 4f); //���� ��Ÿ�� X��ǥ�� �������� ������ �ݴϴ�.
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
    void Gen_Boss() {

        boss_gen_time_check = Time.time;

        if (boss_gen_time_check >= boss_gen_time && bossgen == true) {
            bossgen = false;
            Instantiate(Boss, new Vector3(12, 0, 0f), Quaternion.identity);
            boss_gen_time_check = 0;
        }
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
        InvokeRepeating("SpawnEnemy", 3, 1); //3���� ����, SpawnEnemy�Լ��� 1�ʸ��� �ݺ��ؼ� ���� ��ŵ�ϴ�.
        Boss_Approaching_UI.SetActive(false);
        this.audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        Gen_Boss();
        Boss_generation_condition_Checking();
    }
}