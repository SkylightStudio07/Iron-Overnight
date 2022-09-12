using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType3 : MonoBehaviour
{

    public Animator EnemyC_animator;

    public GameObject Enemy_Bullet;
    public GameObject PlayerPos;
    public Transform FirePos;

    public float hp = 200;

    public int rotateSpeed = 4;


    // Start is called before the first frame update
    void Start()
    {
        PlayerPos = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(Enemy3_Move());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * 0.001f);
        Set_Shooting_Angle();
        if (hp < 0) {
            Destroy(gameObject);
        }

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("AutoRemoveSection"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    
    {
        if (col.gameObject.CompareTag("Bullet"))
        {
            hp -= GameManager.instance.Bullet_Damage;
            EnemyC_animator.SetTrigger("Damaged");
            Destroy(col.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Bullet"))
        {
            EnemyC_animator.SetTrigger("Damaged");
            Destroy(col.gameObject);
        }
    }

    void Set_Shooting_Angle() {

        if (PlayerPos.transform != null) {         
            Vector2 direction = new Vector2(
                transform.position.x - PlayerPos.transform.position.x,
                transform.position.y - PlayerPos.transform.position.y
            );

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // 아크탄젠트 -> 라디안
            // 라디안 -> 각도변환(Rad2Deg)

            Quaternion angleAxis = Quaternion.AngleAxis(angle, Vector3.forward);
            Quaternion rotation = Quaternion.Slerp(transform.rotation, angleAxis, rotateSpeed * Time.deltaTime);
            transform.rotation = rotation;
        }
    }

    IEnumerator Enemy3_Move() {

        while(true)
        {
            yield return null; // 무한반복문 디버깅
            yield return new WaitForSeconds(1f);
            Instantiate(Enemy_Bullet, FirePos.transform.position, FirePos.transform.rotation);
            Debug.Log("Enemy Fired!");
            yield return new WaitForSeconds(1f);
        }
        
    } 

}
