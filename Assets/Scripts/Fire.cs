using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public AudioClip audio_Charge;
    public AudioClip audio_Fire;
    public AudioClip audio_Charge_Shoot;

    public bool Normal_Shooting_Mode = true;

    AudioSource audioSource;

    public GameObject Bullet;
    public GameObject Bullet_Charge;

    public Transform FirePos;

    public float time; 
    public float charging_time = 3;

    public float shoot_delay;


    void Start()
    {
        this.audioSource = GetComponent<AudioSource>();
    }

    void PlaySound(string Player_action) {
        switch (Player_action) {
            case "Fire" :
                audioSource.clip = audio_Fire;
                break;
            case "Charge" :
                audioSource.clip = audio_Charge;
                break;
            case "Charge_Fire" :
                audioSource.clip = audio_Charge_Shoot;
                break;
        }
        audioSource.Play();
    }

    void Shoot() {
        shoot_delay += Time.deltaTime;

        if (shoot_delay > 0.5) {
            Normal_Shooting_Mode = true;
        }

        if (Input.GetKey(KeyCode.Space) && Normal_Shooting_Mode)
        {
            Debug.Log("Fire!");
            PlaySound("Fire");
            Instantiate(Bullet, FirePos.transform.position, FirePos.transform.rotation);
            
            shoot_delay = 0;
            Normal_Shooting_Mode = false;
        }
    }

    void Charging_Shot()
    {
        if (Input.GetKey(KeyCode.V)) {
            Normal_Shooting_Mode = false;
            time += Time.deltaTime;
            Debug.Log("V 키 누르는 중");
        }

        if (Input.GetKeyDown(KeyCode.V)) {
            PlaySound("Charge");
        }

        if (time < charging_time && Input.GetKeyUp(KeyCode.V))
        {
            time = 0;
            Normal_Shooting_Mode = true;
        }

        if (time > charging_time && Input.GetKeyUp(KeyCode.V))
        {
            Debug.Log("Super Fire!");
            PlaySound("Charge_Fire");
            Instantiate(Bullet_Charge, FirePos.transform.position, FirePos.transform.rotation);
            time = 0;
            Normal_Shooting_Mode = true;
        }
    }


    void Update()
    {
        Shoot();
        Charging_Shot();

    }

}