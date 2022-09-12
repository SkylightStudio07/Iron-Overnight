using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public int normal_particle_num = 0;
    public float Bullet_Damage = 10;


    /* 여기서부터는 스테이지 개시 전 변수 초기화 */

    public bool Stage_3_CannnotFire = true;

    /* 여기서부터는 진행상황 체크 */

    public bool isPrologueCleared = false;
    public bool isSecondCleared = false;
    public bool isThirdCleared = false;


    /* 여기서부터는 씬 로드 */

    public IEnumerator END_Stage() {
        yield return new WaitForSeconds(5f);
        LoadingSceneManager.LoadScene("Brave New World");        
    }

}
