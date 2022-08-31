using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class BackgroundControl : MonoBehaviour
{
	public float scrollSpeed = 0.5f; // 백그라운드 스크롤 스피드
	Material myMaterial; // 마테리얼

	// Use this for initialization

	void Start()
	{
		myMaterial = GetComponent<Renderer>().material; // 매터리얼 받아오기
	}

	// Update is called once per frame

	void Update()

	{
		float newOffsetX = myMaterial.mainTextureOffset.x + scrollSpeed * Time.deltaTime;
		Vector2 newOffset = new Vector2(newOffsetX, 0);

		myMaterial.mainTextureOffset = newOffset;

	}

}