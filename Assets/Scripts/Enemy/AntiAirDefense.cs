using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiAirDefense : MonoBehaviour
{
    public GameObject Enemy_Bullet;
    public GameObject PlayerPos;

    public int rotateSpeed = 4;


    // Start is called before the first frame update
    void Start()
    {
        PlayerPos = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(AntiAircraftGun());
    }

    // Update is called once per frame
    void Update()
    {
        Set_Shooting_Angle();
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

            Quaternion angleAxis = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            Quaternion rotation = Quaternion.Slerp(transform.rotation, angleAxis, rotateSpeed * Time.deltaTime);
            transform.rotation = rotation;
        }
    }

    IEnumerator AntiAircraftGun() {

        while(true)
        {
            yield return new WaitForSeconds(2f);
            for(int i = 0; i < 19; i++) {
                Instantiate(Enemy_Bullet, transform.position, transform.rotation);
                yield return new WaitForSeconds(0.2f);
            }
            yield return new WaitForSeconds(2f);
        }
        
    } 
}
