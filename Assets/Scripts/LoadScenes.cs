using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadPrologue() {
        LoadingSceneManager.LoadScene("Prologue");
    }

    public void LoadStage2() {
        LoadingSceneManager.LoadScene("Stage 2");
    }

    public void LoadStage3() {
        LoadingSceneManager.LoadScene("Stage 3");
    }

    public void LoadStage4() {
        LoadingSceneManager.LoadScene("Stage 4");
    }

}
