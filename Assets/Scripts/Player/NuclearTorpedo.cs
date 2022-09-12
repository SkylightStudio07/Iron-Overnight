using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuclearTorpedo : MonoBehaviour
{
    float Torpedo_Damage = 6000;
    public GameObject Particle_2;

    // Stage 3에서만 한정 사용

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
            StartCoroutine(Nuclear_Torpedo_Launch());
      
    }
    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Boss")
        {
            Enemy_Boss enemyboss = GameObject.Find("Boss(Clone)").GetComponent<Enemy_Boss>();
            enemyboss.BossHP -= Torpedo_Damage;
            enemyboss.animator.SetTrigger("Damaged");
            Instantiate(Particle_2, gameObject.transform.position + new Vector3(0, 0, -1), gameObject.transform.rotation);
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "AutoRemoveSection")
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Nuclear_Torpedo_Launch() {
        EnemySpawn enemyspawn = GameObject.Find("SpawnManager").GetComponent<EnemySpawn>();
        if (enemyspawn.bossgen == false) {
            yield return new WaitForSeconds(5f);
            transform.parent = null;
            transform.Translate(Vector3.left * 0.001f);
        }   
    }
}
