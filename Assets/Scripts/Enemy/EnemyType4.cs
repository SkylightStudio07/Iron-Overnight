using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType4 : MonoBehaviour
{

    public GameObject PlayerPos;

    public int rotateSpeed = 4;


    // Start is called before the first frame update
    void Start()
    {
        PlayerPos = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * 0.009f);
        Set_Shooting_Angle();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("AutoRemoveSection"))
        {
            Destroy(gameObject);
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

}
