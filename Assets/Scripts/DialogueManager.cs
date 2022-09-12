using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{

    public Text DiaName;
    public Text DiaTalk;
    public bool Boss_Approchaing;
    public bool Stage_Start_Check = true;
    public bool i_identifier = true;

    PlayerController playercontroller;

    int i = 0;
    string[] talktextdata;

    public GameObject DialogueUI;
    public GameObject Panel;

    void SceneCheck() {
        if (SceneManager.GetActiveScene().name == "Prologue" && Stage_Start_Check == true) {
            Dialogue("Prologue_Start");   
        }
        if (SceneManager.GetActiveScene().name == "Stage 2" && Stage_Start_Check == true) {
            Dialogue("Stage_2_Start");   
        }
        if (SceneManager.GetActiveScene().name == "Stage 3" && Stage_Start_Check == true) {
            Dialogue("Stage_3_Start");   
        }
        if (SceneManager.GetActiveScene().name == "Stage 4" && Stage_Start_Check == true) {
            Dialogue("Stage_4_Start");   
        }
    }

    void BossApproachCheck() {
        if (SceneManager.GetActiveScene().name == "Prologue" && Stage_Start_Check == false) {
            {
                EnemySpawn enemyspawn = GameObject.Find("SpawnManager").GetComponent<EnemySpawn>();
                if(enemyspawn.bossgen == false) {
                    Dialogue("Prologue_Boss_Approach");
                }
            }
        }
        if (SceneManager.GetActiveScene().name == "Stage 2" && Stage_Start_Check == false) {
            {
                EnemySpawn enemyspawn = GameObject.Find("SpawnManager").GetComponent<EnemySpawn>();
                if(enemyspawn.bossgen == false) {
                    Dialogue("Stage2_Boss_Approach");
                }
            }
        }
        if (SceneManager.GetActiveScene().name == "Stage 3" && Stage_Start_Check == false) {
            {
                EnemySpawn enemyspawn = GameObject.Find("SpawnManager").GetComponent<EnemySpawn>();
                if(enemyspawn.bossgen == false) {
                    Dialogue("Stage3_Boss_Approach");
                }
            }
        }  
        if (SceneManager.GetActiveScene().name == "Stage 4" && Stage_Start_Check == false) {
            {
                EnemySpawn enemyspawn = GameObject.Find("SpawnManager").GetComponent<EnemySpawn>();
                if(enemyspawn.bossgen == false) {
                    Dialogue("Stage4_Boss_Approach");
                }
            }
        }         
    }

    // Start is called before the first frame update
    void Start()
    {
        Stage_Start_Check = true;
        GameManager.instance.Normal_Shooting_Mode = false;                
    }

    // Update is called once per frame
    void Update()
    {
        SceneCheck();
        BossApproachCheck();
    }

    void Dialogue(string Situation) {

        // 여기서부터 프롤로그 다이얼로그 세터

        if(Situation == "Prologue_Start") {

            DiaName.text = "도웬 준장";
            string[] talktextdata = { "여기는 베식타스-6 전대 대장 도웬 준장이다.\n테라 노바 방공사령부, 응답하라!", 
            "뉴 센다이 상공의 모든 아군 항공기는 응답하라! 누구 없나!?",
            "대위? 귀관 외에는 유감스럽게도 전부 전멸한 모양이군...", 
            "자살 임무와 다를 바 없는 임무지만, 해주어야 할 일이 있다, 대위.", 
            "최대한 많은 요격기들을 격추시켜서,\n공화국의 인민들이 최대한 피난할 수 있도록 돕도록!\n모두의 목숨이 귀관에 달려있다!", 
            "볼프람 방공기지에 아직 아군 항공기가 남아있다.\n최대한 빨리 지원병력을 보내주도록 하지."};
            returnDialogue(talktextdata);
        }


        if(Situation == "Prologue_Boss_Approach") {
            initiating_I();
            DiaName.text = "도웬 준장";
            string[] talktextdata = {"", // 더미
                "동향부 200마일에서... 중형 적성 함체 접근중!!", 
            "색적요원에 따르면, 미확인 비행체는 커레이저스급 경순양함으로 예상된다.",
            "대위, 정신 바짝 차리게! 뇌격을 적극적으로 활용해서 적함을 격침시켜!." };
            DiaTalk.text = talktextdata[0]; 
            returnDialogue(talktextdata);

        }   

        if(Situation == "Stage_2_Start") {

            DiaName.text = "제임스 판 테일러";
            string[] talktextdata = { "뉴 바오딩의 아이기스 7 채굴기지에서 도움을 필요로 합니다!", 
            "광부들이 피난하기도 전에 양자 미사일 공습이 시작되었습니다!\n이대로라면 전부 뒈질 거라고요!",
            "...대위님이시군요! 이름난 테라 노바의 영웅님을 뵙습니다.", 
            "힘든 일이겠지만, 하나만 부탁드리겠습니다.\n 저 빌어먹을 스티리아군의 미사일 모함을 격추시켜야 합니다.", 
            "적 모항 주변에서 다수의 적 제공기가 감지되었습니다. 힘든 싸움이 될 겁니다.", 
            "...이런! 이쪽이 색적당했습니다!\n엄청난 수의 대공 미사일들이 관측됩니다, 부디 무사하십시오, 대위님!"};
            returnDialogue(talktextdata);
        }

        if(Situation == "Stage2_Boss_Approach") {
            initiating_I();
            DiaName.text = "제임스 판 테일러";
            string[] talktextdata = {"", // 더미
                "잡았다, 이 개자식.", 
            "적 미사일 모함입니다! 그것도... 신형이로군요.",
            "어마어마하게 저항할 겁니다, 대비하십시오!" };
            DiaTalk.text = talktextdata[0]; 
            returnDialogue(talktextdata);

        }

        if(Situation == "Stage_3_Start") {

            DiaName.text = "투브신바야르 상장";
            string[] talktextdata = { "오오, 귀관이 그 이름난 대위인가, 과연 걸물이군.", 
            "귀국과 귀관이 우리 소비에트의 요청을 받아들인 것에 대해 감사를 표하도록 하지.",
            "작전 목표는 도주하는 적 순양전함, 브륀힐드를 날려버리는 것.\n그것 하나뿐일세.", 
            "아아, 너무 걱정하지는 말게.\n귀관이 할 일은 우리 항공군이 목숨 바쳐서 시간을 끌 때\n저 지랄맞은 새끼의 함교에 어뢰 하나만 날려주면 되는 거니까.", 
            "귀관의 기체에 핵융합 어뢰를 하나 장착시켜두었네.\n문제는 어뢰의 안정성 때문에 투하하기 전까진 다른 무장을\n사용할 수 없을 걸세. 아무쪼록, 조심하게.", 
            "행운을 빌지. 제국주의자들의 압제에 대항하는 동지로서, 경의를 표하지!\n인민을 위하여, 소비에트를 위하여!"};
            returnDialogue(talktextdata);
        }

        if(Situation == "Stage3_Boss_Approach") {
            initiating_I();
            DiaName.text = "투브신바야르 상장";
            string[] talktextdata = {"", // 더미
                "브륀힐드여, 도망갈 수 없을 거다.\n이번에야말로... 말이지.", 
            "인민을 수도 없이 잡아먹은 저 괴물에게\n지옥불을 선사해주게, 대위!", };
            DiaTalk.text = talktextdata[0]; 
            returnDialogue(talktextdata);

        }

        if(Situation == "Stage_4_Start") {

            DiaName.text = "사령부 참모장 유키무라";
            string[] talktextdata = { "영광스러운 싸움이 시작된다!", 
            "우리 공화국군은 여기서 적의 증원함대를 저지한다.\n작전 목표는 적 항공세력의 섬멸!",
            "대위, 이야기는 많이 들었네. 귀관은 실로 우리 공화국의 자랑이야.", 
            "귀관이 할 일은 난전에 끼어드는 적 요격기 편대를 저지하도록 하게.\n아군기들이 자네와 함께 싸워줄 것이야.", 
            "아크라이트 항성계의 용병부대들이 적에게 고용되어 전쟁에 끼어들었네.\n'이리' 편대가 자네를 노리고 있어.", 
            "조심하되, 용병 나부랭이들이 싸움을 걸어오면 갈아버리게!"};
            returnDialogue(talktextdata);
        }
        if(Situation == "Stage4_Boss_Approach") {
            initiating_I();
            DiaName.text = "이리 편대 대장 빅토르";
            string[] talktextdata = {"", // 더미
                "이리가 토끼를 물어뜯으러 왔다."}; 
            DiaTalk.text = talktextdata[0]; 
            returnDialogue(talktextdata);

        }    

    }

    void returnDialogue(string[] talktextdata) {
        if (i < talktextdata.Length) {
                DiaTalk.text = talktextdata[i]; 
            }
                if(Input.GetKeyDown(KeyCode.Space) && i < talktextdata.Length) {

                    i++;

                    if(i == talktextdata.Length) {
                        DiaName.gameObject.SetActive(false);
                        DiaTalk.gameObject.SetActive(false);
                        DialogueUI.SetActive(false);
                        Panel.SetActive(false);
                        
                        GameManager.instance.Normal_Shooting_Mode = true;
                        GameManager.instance.isMove = true;

                        Time.timeScale = 1;
                        Stage_Start_Check = false;

                    }
                    else if (i < talktextdata.Length) {
                        GameManager.instance.Normal_Shooting_Mode = false;

                        DiaName.gameObject.SetActive(true);
                        DiaTalk.gameObject.SetActive(true);
                        DialogueUI.SetActive(true);
                        Panel.SetActive(true);
                        Debug.Log(i);
                        Debug.Log(talktextdata.Length);                        
                        DiaTalk.text = talktextdata[i];
                        Time.timeScale = 0;

                    }
                }            
    }

    void initiating_I() { // i 초기화
        if (i_identifier == true) {
            i = 0;
            i_identifier = false;
        }
    }

}
