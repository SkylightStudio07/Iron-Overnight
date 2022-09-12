using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SFX : MonoBehaviour
{

    public AudioClip Victory;   
    public AudioClip audio_Damage;
    public AudioClip audio_Burst;

    public AudioClip Prologue_BGM;
    public AudioClip Stage_2_BGM;


    AudioSource audioSource;

    // Start is called before the first frame update

    void Start()
    {
        StageCheck();
    }

    void Awake()
    {
        this.audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Victory_Check() {
        EnemySpawn enemyspawn = GameObject.Find("SpawnManager").GetComponent<EnemySpawn>();
        if (enemyspawn.boss_defeated == true) {
            PlaySound("Victory");
        }
    }

    void StageCheck() {
        if (SceneManager.GetActiveScene().name == "Prologue") {
            PlaySound("Prologue");
        }
        if (SceneManager.GetActiveScene().name == "Stage 2") {
            PlaySound("Stage_2");
        }
    }

    void PlaySound(string Action) {
        switch (Action) {
            case "Victory" :
                audioSource.clip = Victory;
                break;
            case "Prologue" :
                audioSource.clip = Prologue_BGM;
                break;
            case "Stage_2" :
                audioSource.clip = Stage_2_BGM;
                break;
        }
           
        audioSource.Play();
    }

}
