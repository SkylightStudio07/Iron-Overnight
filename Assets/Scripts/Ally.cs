using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : MonoBehaviour
{
    public GameObject Particle_1;
    public Transform FirePos;
    public GameObject Bullet;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Ally_Shoot");
    }

    // Update is called once per frame
    void Update() {

        transform.position = Vector3.Lerp (transform.position, new Vector2(-6, transform.position.y), 0.001f);   // 부드럽게 이동 
    }

    IEnumerator Ally_Shoot() {
        while(true)
        {
            yield return null; // 무한반복문 디버깅
            yield return new WaitForSeconds(2f);
            Instantiate(Bullet, FirePos.transform.position, FirePos.transform.rotation);
            yield return new WaitForSeconds(2f);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy_N")
        {
            Destroy(col.gameObject);
            Instantiate(Particle_1, gameObject.transform.position + new Vector3(0, 0, -1), gameObject.transform.rotation);
            Destroy(gameObject);
        }        
    }

}
