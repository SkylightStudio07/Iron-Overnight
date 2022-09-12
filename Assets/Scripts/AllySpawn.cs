using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllySpawn : MonoBehaviour
{
    public GameObject Ally_1_Arrived_UI;
    public GameObject Ally;

    public void SpawnAlly() {


        StartCoroutine("UI_Master");

        Debug.Log("Ally Arrived!");
        Instantiate(Ally, new Vector3(-9, 2, 0f), Quaternion.identity);
        Instantiate(Ally, new Vector3(-9, 0, 0f), Quaternion.identity);
        Instantiate(Ally, new Vector3(-9, -2, 0f), Quaternion.identity);
        Instantiate(Ally, new Vector3(-9, -4, 0f), Quaternion.identity);        

    }

    public void SpawnAlly_Strengthen() {


        StartCoroutine("UI_Master");

        Debug.Log("Ally Arrived!");
        Instantiate(Ally, new Vector3(-9, 2, 0f), Quaternion.identity);
        Instantiate(Ally, new Vector3(-9, 1, 0f), Quaternion.identity);
        Instantiate(Ally, new Vector3(-9, 0, 0f), Quaternion.identity);
        Instantiate(Ally, new Vector3(-9, -1, 0f), Quaternion.identity);
        Instantiate(Ally, new Vector3(-9, -2, 0f), Quaternion.identity);
        Instantiate(Ally, new Vector3(-9, -3, 0f), Quaternion.identity);
        Instantiate(Ally, new Vector3(-9, -4, 0f), Quaternion.identity);        

    }

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Prologue") {
            InvokeRepeating("SpawnAlly", 20, 25);
        }

        else if (SceneManager.GetActiveScene().name == "Stage 4") {
            InvokeRepeating("SpawnAlly_Strengthen", 5, 15);
        }             
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator UI_Master() {
        Ally_1_Arrived_UI.SetActive(true);
        yield return new WaitForSeconds(10f);
        Ally_1_Arrived_UI.SetActive(false);        
    }
        
    
}
