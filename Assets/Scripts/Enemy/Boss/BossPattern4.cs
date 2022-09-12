using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPattern4 : MonoBehaviour
{

    public float boss_speed = 0.02f;

    public GameObject PlayerPos;

    public GameObject Boss_Stage_2_Bullet;
    public GameObject Boss_Stage_2_Torpedo;
    public Transform Boss_FirePos;
    public Transform Boss_MissilePos;

    public int rotateSpeed = 6;

    void Boss_Move() {
        transform.Translate(new Vector3(0, PlayerPos.transform.position.y - gameObject.transform.position.y, 0) * Time.deltaTime * boss_speed);
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

        viewPos.y = Mathf.Clamp01(viewPos.y);

        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
        transform.position = worldPos;
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(transform.position.x - 5, transform.position.y);
        PlayerPos = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(Pattern2());
    }

    // Update is called once per frame
    void Update()
    {
        Boss_Move();
        Set_Shooting_Angle(); 
        GoBack();              
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

    IEnumerator Pattern2() {
        while(true) {
        yield return new WaitForSeconds(1.5f);

        for(int i = 0; i<8; i++) {
            Instantiate(Boss_Stage_2_Torpedo, Boss_MissilePos.transform.position, Boss_MissilePos.transform.rotation);
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(1.0f);

        for(int i = 0; i<20; i++) {
            Instantiate(Boss_Stage_2_Bullet, Boss_FirePos.transform.position, Boss_FirePos.transform.rotation);
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(1.5f);
    }

    }

    void GoBack() { // x좌표 보정
        if(transform.position.x != 0) {
            transform.position = new Vector2(7, transform.position.y);
        }
    }

    }

