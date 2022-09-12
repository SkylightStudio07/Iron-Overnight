using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progress : MonoBehaviour
{

    [SerializeField]private Button ST1;
    [SerializeField]private Button ST2;
    [SerializeField]private Button ST3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Progess_Check();
    }

    void Progess_Check() {
        if (GameManager.instance.isPrologueCleared == true) {
            ST2.interactable = true;
            if(GameManager.instance.isSecondCleared == true) {
                ST3.interactable = true;    
            }
        }
    }
}
