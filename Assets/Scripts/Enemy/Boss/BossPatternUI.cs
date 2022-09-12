using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPatternUI : MonoBehaviour
{
    // Start is called before the first frame update
    public float DestroyTime = 3.0f;
    void Start () 
    {
        Destroy(gameObject, DestroyTime); 
        }


    // Update is called once per frame
    void Update()
    {
        
    }
}
