using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null; 

    private void Awake()
    {
        if (instance == null) 
        {
            instance = this; 
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            if (instance != this) 
                Destroy(this.gameObject); 
        }
    }

    // 여기서부터는 플레이어 사격 관제

    // Normal_Shooting_Mode
    // time
    // charging_time
    
    public float charging_time = 3;
    public bool Normal_Shooting_Mode;
    public bool isMove = false;

}
