using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType7 : MonoBehaviour
{
    public Animator EnemyE_animator;
    public GameObject Particle_1;
    public GameObject Particle_2;

    public GameObject Enemy_Torpedo;
    public GameObject PlayerPos;
    public Transform FirePos;

    public float hp = 150;
    public float enemy_speed = 0.5f;

    public int rotateSpeed = 2;


    // Start is called before the first frame update
    void Start()
    {
        PlayerPos = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(Enemy7_Move());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * 0.001f);
        Set_Shooting_Angle();
        if (hp < 0) {
            Instantiate(Particle_2, gameObject.transform.position + new Vector3(0, 0, -1), gameObject.transform.rotation);
            Destroy(gameObject);
        }
        Enemy_Move();

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
            Instantiate(Particle_1, gameObject.transform.position + new Vector3(0, 0, -1), gameObject.transform.rotation);
            hp -= GameManager.instance.Bullet_Damage;
            EnemyE_animator.SetTrigger("Damaged");
            Destroy(col.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Bullet"))
        {
            EnemyE_animator.SetTrigger("Damaged");
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

    IEnumerator Enemy7_Move() {

        while(true)
        {
            yield return null; // 무한반복문 디버깅
            yield return new WaitForSeconds(3f);

            Instantiate(Enemy_Torpedo, FirePos.transform.position, FirePos.transform.rotation);
        
            Debug.Log("Enemy Fired!");
            yield return new WaitForSeconds(3f);
        }
        
    } 

    void Enemy_Move() {
        transform.Translate(new Vector3(0, PlayerPos.transform.position.y - gameObject.transform.position.y, 0) * Time.deltaTime * enemy_speed);
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

        viewPos.y = Mathf.Clamp01(viewPos.y);

        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
        transform.position = worldPos;
    }
}
