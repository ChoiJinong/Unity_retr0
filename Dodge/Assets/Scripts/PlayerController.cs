using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody; // 이동에 사용할 리지드바디 컴포넌트
    public float speed = 8f; // 이동 속력

    void Start()
    {
        // 게임 오브젝트 중 Rigidbody 컴포넌트 찾아 할당
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 키보드 입력 ver.01
        // -> 문제점 1. 입력이 게임에 즉시 반영되지 않음
        // -> 문제점 2. 입력 감지 코드 복잠
        // -> 문제점 3. playerRigidbody 컴포넌트 할당 불편
        /*
        if (Input.GetKey(KeyCode.UpArrow) == true)
            playerRigidbody.AddForce(0f,0f,speed);
        if (Input.GetKey(KeyCode.DownArrow) == true)
            playerRigidbody.AddForce(0f, 0f, -speed);
        if (Input.GetKey(KeyCode.LeftArrow) == true)
            playerRigidbody.AddForce(-speed, 0f, 0f);
        if (Input.GetKey(KeyCode.RightArrow) == true)
            playerRigidbody.AddForce(speed, 0f, 0f);
        */

        // 키보드 입력 ver.02
        // 수평축과 수직축의 입력값 감지 후 저장
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");
        // 실제 이동 속도를 입력값과 이동 속력을 사용해 결정
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;
        // Vector3 속도를 새롭게 생성
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        // 생성한 속도를 리지드바디의 속도에 할당
        playerRigidbody.velocity = newVelocity;
    }

    public void Die()
    {
        gameObject.SetActive(false); // player 게임 오브젝트 비활성화
    }
}
