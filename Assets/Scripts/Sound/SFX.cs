using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{

    public AudioClip Siren;
    public AudioClip audio_Charge_Shoot;   
    public AudioClip audio_Damage;
    public AudioClip audio_Burst;
    AudioSource audioSource;

    // Start is called before the first frame update

    void Start()
    {
        
    }

    void Awake()
    {
        this.audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Boss_Warning_Sound();
    }

    void Boss_Warning_Sound() {
        EnemySpawn enemyspawn = GameObject.Find("SpawnManager").GetComponent<EnemySpawn>();
        if(enemyspawn.bossgen == false) {
            PlaySound("Siren");
        }
    }

    void PlaySound(string Action) {
        switch (Action) {
            case "Siren" :
                audioSource.clip = Siren;
                break;
        }
        audioSource.Play();
    }

}
