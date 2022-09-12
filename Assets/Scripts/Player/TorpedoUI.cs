using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TorpedoUI : MonoBehaviour
{

    public float Torpedo_Cooltime = 30f;
    Image Torpedo_Cooltime_Bar;
    public bool Cooltime_available_1 = false;

    public float Torpedo_Timer;

    /* void Torpedo_Manager() {
        AlphaAttack alphaattack = GameObject.Find("Square").GetComponent<AlphaAttack>();
        if (alphaattack.Torpedo_Attack_Available == false) {
            Torpedo_Timer = Time.time;      
            Torpedo_Cooltime_Bar.enabled = true;
            Torpedo_Cooltime_Bar.fillAmount = (Torpedo_Cooltime - Torpedo_Timer) / Torpedo_Cooltime;
        }
        if(Torpedo_Cooltime_Bar.fillAmount <= 0 && alphaattack.Torpedo_Attack_Available == false) {
            alphaattack.Torpedo_Attack_Available = true;
            DoTimerOffset(Cooltime_available_1);
            Cooltime_available_1 = true;
        }
    } */

    void Start()
    {
        Torpedo_Cooltime_Bar = GetComponent<Image>();
        Torpedo_Cooltime_Bar.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        AlphaAttack alphaattack = GameObject.Find("Square").GetComponent<AlphaAttack>();
        if(alphaattack.Torpedo_Attack_Available == false) {
            StartCoroutine(TorpedoCooltime(Torpedo_Cooltime));
        }
    }

    IEnumerator TorpedoCooltime(float cooltime) {
        Torpedo_Cooltime_Bar.enabled = true;
        while(cooltime>1.0f)
            { cooltime -= Time.time;
                Torpedo_Cooltime_Bar.fillAmount = (1.0f / cooltime);
                yield return new WaitForFixedUpdate(); }
    }
}
