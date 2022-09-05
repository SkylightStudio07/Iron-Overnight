using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaAttack : MonoBehaviour
{
    public bool Torpedo_Attack_Available = true;
    public GameObject Torpedo;


    void Alpha_Attack_Torpedo() {
        if (Input.GetKeyDown(KeyCode.B) && Torpedo_Attack_Available == true) {
            Fire fire = GameObject.Find("Square").GetComponent<Fire>();
            GameManager.instance.Normal_Shooting_Mode = false;
            Instantiate(Torpedo, fire.FirePos.transform.position, fire.FirePos.transform.rotation);
            Torpedo_Attack_Available = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Alpha_Attack_Torpedo();
    }
}
