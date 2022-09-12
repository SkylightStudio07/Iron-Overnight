using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneManager : MonoBehaviour
{
    public static string nextScene;
    [SerializeField]Image progressBar;

    public GameObject DefaultImg;
    public GameObject PrologueImg;
    public GameObject Stage2Img;
    public GameObject Stage3Img;    
    public GameObject TapSpaceText;

    public Text Tip;

    private void Start()
    {
        RandomTip();
        NextSceneCheck();
        StartCoroutine(LoadScene());
    }

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }

    IEnumerator LoadScene()
    {
        yield return null;
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene); // 비동기연산 코루틴

        op.allowSceneActivation = false;
        float timer = 0.0f;

        while (!op.isDone)
        {
            yield return null;
            timer += Time.deltaTime;
            if (op.progress < 0.9f)
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, op.progress, timer);
                if (progressBar.fillAmount >= op.progress)
                {
                    timer = 0f;
                }
            }
            else
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f, timer);
                if (progressBar.fillAmount == 1.0f)
                {
                    TapSpaceText.SetActive(true);
                    if (Input.GetKey(KeyCode.Space)) {
                        op.allowSceneActivation = true;
                        yield break;
                    }
                }
            }
        }
    }

    void NextSceneCheck() {
        if (nextScene == "Prologue") {
            DefaultImg.SetActive(false);
            PrologueImg.SetActive(true);
        }
        else if (nextScene == "Stage 2") {
            DefaultImg.SetActive(false);
            Stage2Img.SetActive(true);
        }
        else if (nextScene == "Stage 3") {
            DefaultImg.SetActive(false);
            Stage3Img.SetActive(true);
        }
    }

    void RandomTip() {
        int random = Random.Range(0, 3); {
            if(random == 0) {
                Tip.text = "Tip : 뇌격으로 보스에게 강력한 피해를 입힐 수 있습니다.";
            }
            if(random == 1) {
                Tip.text = "Tip : 공격의 기세를 이어나가기 위해 증원군을 요청하세요.";
            }
            if(random == 2) {
                Tip.text = "Tip : 보스가 공격할 때에는 덩달아 공격하기보다는 회피를 우선하는 것이 좋습니다.";
            }
        } 
    }
}