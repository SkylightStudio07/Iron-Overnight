using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ChargeCheck : MonoBehaviour
{
    public GameObject Charge_Check;

    // Start is called before the first frame update
    void Start()
    {
        Charge_Check.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Charge_Checking();
    }

    void Charge_Checking() {
        Fire fire = GameObject.Find("Square").GetComponent<Fire>();
        if (fire.time > GameManager.instance.charging_time) {
            Charge_Check.SetActive(true);
        }
        else {
            Charge_Check.SetActive(false);
        }
    }
}
