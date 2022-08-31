using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 0.1f;
    private Animator anim; // Animator�� �ҷ����� ���� ����

    // Use this for initialization

    void Start()

    {
        anim = GetComponent<Animator>();
    }

    void MoveControl()

    {
        float moveX = moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float moveY = moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");
        transform.Translate(moveX, moveY, 0);

        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

        viewPos.y = Mathf.Clamp01(viewPos.y);
        viewPos.x = Mathf.Clamp01(viewPos.x);

        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
        transform.position = worldPos;
    }

    // Update is called once per frame

    void Update()

    {
        MoveControl();
        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
    }
}