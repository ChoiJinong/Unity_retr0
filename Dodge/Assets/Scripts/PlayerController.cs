using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody; // �̵��� ����� ������ٵ� ������Ʈ
    public float speed = 8f; // �̵� �ӷ�

    void Start()
    {
        // ���� ������Ʈ �� Rigidbody ������Ʈ ã�� �Ҵ�
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Ű���� �Է� ver.01
        // -> ������ 1. �Է��� ���ӿ� ��� �ݿ����� ����
        // -> ������ 2. �Է� ���� �ڵ� ����
        // -> ������ 3. playerRigidbody ������Ʈ �Ҵ� ����
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

        // Ű���� �Է� ver.02
        // ������� �������� �Է°� ���� �� ����
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");
        // ���� �̵� �ӵ��� �Է°��� �̵� �ӷ��� ����� ����
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;
        // Vector3 �ӵ��� ���Ӱ� ����
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        // ������ �ӵ��� ������ٵ��� �ӵ��� �Ҵ�
        playerRigidbody.velocity = newVelocity;
    }

    public void Die()
    {
        gameObject.SetActive(false); // player ���� ������Ʈ ��Ȱ��ȭ
    }
}
