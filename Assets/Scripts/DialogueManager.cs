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

    PlayerController playercontroller;
    int i = 0;
    string[] talktextdata;

    public GameObject DialogueUI;
    public GameObject Panel;

    void SceneCheck() {
        if (SceneManager.GetActiveScene().name == "Prologue") {
            Dialogue("Prologue");   
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        GameManager.instance.Normal_Shooting_Mode = false;                
    }

    // Update is called once per frame
    void Update()
    {
        SceneCheck();
    }

    void Dialogue(string SceneName) {
        if(SceneName == "Prologue") {

            DiaName.text = "도웬 준장";
            string[] talktextdata = { "여기는 베식타스-6. 방공사령부, 응답하라!", 
            "...염병할! 뉴 센다이 상공의 모든 아군 항공기는 응답하라! 누구 없나!?" };
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

                    }
                    else if (i < talktextdata.Length) {
                        Debug.Log(i);
                        Debug.Log(talktextdata.Length);                        
                        DiaTalk.text = talktextdata[i];
                    }
                }            
        }
    }

}
