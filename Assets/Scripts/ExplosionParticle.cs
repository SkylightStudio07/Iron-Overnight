using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionParticle : MonoBehaviour
{
    public float DestroyTime = 1.5f;
    void Start () 
    {
        Destroy(gameObject, DestroyTime); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
