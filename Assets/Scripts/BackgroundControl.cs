using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class BackgroundControl : MonoBehaviour
{
	public float scrollSpeed = 0.5f; // ��׶��� ��ũ�� ���ǵ�
	Material myMaterial; // ���׸���

	// Use this for initialization

	void Start()
	{
		myMaterial = GetComponent<Renderer>().material; // ���͸��� �޾ƿ���
	}

	// Update is called once per frame

	void Update()

	{
		float newOffsetX = myMaterial.mainTextureOffset.x + scrollSpeed * Time.deltaTime;
		Vector2 newOffset = new Vector2(newOffsetX, 0);

		myMaterial.mainTextureOffset = newOffset;

	}

}