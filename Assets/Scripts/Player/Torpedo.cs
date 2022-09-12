using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torpedo : MonoBehaviour
{

    float Bullet_Damage = 200;
    public GameObject Particle_1;
    public GameObject Particle_2;
    public GameObject FlameEffect;

    // Start is called before the first frame update
    void Start()
    {       
    }

    void Torpedo_Launch() {
        StartCoroutine(Launch());       
    }

    // Update is called once per frame
    void Update()
    {
        Torpedo_Launch();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy_N")
        {
            Destroy(col.gameObject);
            Debug.Log("Enemy Destroyed by Player");
            Instantiate(Particle_1, gameObject.transform.position + new Vector3(0, 0, -1), gameObject.transform.rotation);
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Boss")
        {
            Enemy_Boss enemyboss = GameObject.Find("Boss(Clone)").GetComponent<Enemy_Boss>();
            enemyboss.BossHP -= Bullet_Damage;
            enemyboss.animator.SetTrigger("Damaged");
            Debug.Log("Damaged Enemy");
            Instantiate(Particle_2, gameObject.transform.position + new Vector3(0, 0, -1), gameObject.transform.rotation);
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "AutoRemoveSection")
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Launch() {
        transform.Translate(Vector3.down * 0.01f);
        yield return new WaitForSeconds(0.5f);
        //GameObject MyFlame = Instantiate(FlameEffect, gameObject.transform.position, gameObject.transform.rotation);
        //MyFlame.transform.SetParent(this.transform);
        //yield return new WaitForSeconds(0.5f);
        //Destroy(MyFlame);
        transform.Translate(new Vector3(1, 0.4f, 0) * 0.03f);
    }
}
