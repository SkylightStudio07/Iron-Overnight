using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Guage : MonoBehaviour
{
    Image Charge_Bar;
    float max = 3;

    // Start is called before the first frame update
    void Start()
    {
        Charge_Bar = GetComponent<Image>();
    }

    // Update is called once per frame
    private void Update()
    {
	    Charge_Shoot_bar();
    }

    public void Charge_Shoot_bar() 
    {
    Fire fire = GameObject.Find("Square").GetComponent<Fire>();

	float Charging_Guage = fire.time; 
	Charge_Bar.fillAmount = Charging_Guage / max;
    }   
}
