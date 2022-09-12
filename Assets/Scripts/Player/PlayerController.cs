using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject Particle_1;
    public GameObject GameOver;
    public float moveSpeed = 0.1f;
    private Animator anim; 

    // Use this for initialization

    void Start()

    {
        anim = GetComponent<Animator>();
        Stage_3_Set_Position();
    }

    void MoveControl() {
    if (SceneManager.GetActiveScene().name != "Stage 3") 
        {
            float moveX = moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
            float moveY = moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");
            transform.Translate(moveX, moveY, 0);
        }

    else if (SceneManager.GetActiveScene().name == "Stage 3") 
        {
            float moveX = moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");
            float moveY = moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
            transform.Translate(-1 * moveX, moveY, 0);
        }

        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

        viewPos.y = Mathf.Clamp01(viewPos.y);
        viewPos.x = Mathf.Clamp01(viewPos.x);

        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
        transform.position = worldPos;
    }
    private void OnTriggerEnter2D(Collider2D col)
    
    {
        if(gameObject.tag == "Player") {
            if (col.gameObject.CompareTag("Enemy_Bullet"))
            {
                Instantiate(Particle_1, gameObject.transform.position + new Vector3(0, 0, -1), gameObject.transform.rotation);
                Destroy(col.gameObject);
                StartCoroutine(DeathCheck());
            }
            if (col.gameObject.CompareTag("Enemy_N"))
            {
                Instantiate(Particle_1, gameObject.transform.position + new Vector3(0, 0, -1), gameObject.transform.rotation);
                Destroy(col.gameObject);
                StartCoroutine(DeathCheck());
            }
            if (col.gameObject.CompareTag("Enemy"))
            {
                Instantiate(Particle_1, gameObject.transform.position + new Vector3(0, 0, -1), gameObject.transform.rotation);
                StartCoroutine(DeathCheck());
            }
            if (col.gameObject.CompareTag("Boss"))
            {
                Instantiate(Particle_1, gameObject.transform.position + new Vector3(0, 0, -1), gameObject.transform.rotation);
                StartCoroutine(DeathCheck());
            }
        }
    }

    // Update is called once per frame

    void Update()

    {
        if (GameManager.instance.isMove == true) {
            MoveControl();
            anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
            anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        }
    }

    void Stage_3_Set_Position() {
    if (SceneManager.GetActiveScene().name == "Stage 3") 
        {
            transform.Rotate(0, 0, -90);
            transform.position = new Vector2(0, 3);
        }        
    }

    IEnumerator DeathCheck() {
        GameManager.instance.isMove = false;
        GameManager.instance.Stage_3_CannnotFire = false;
        GameOver.SetActive(true);
        yield return new WaitForSeconds(5.0f);
        LoadingSceneManager.LoadScene("Brave New World"); 
    }

}