using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;

    private Transform target;       // �߻��� -> �÷��̾�
    private float spawnRate;        // �����ֱ�
    private float timeAfterSpawn;   //�ֱ� ������������ ���� �ð�

    void Start()
    {
        // �����ð� �ʱ�ȭ
        timeAfterSpawn = 0f;
        // ���� ���� ���� ����
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        // �÷��̾� ����
        target = FindObjectOfType<PlayerController>().transform;
    }

    void Update()
    {
        // timeAfterSpawn ����
        timeAfterSpawn += Time.deltaTime;
        if (timeAfterSpawn >= spawnRate)
        {
            // ���� �ð� �ʱ�ȭ
            timeAfterSpawn = 0f;
            // �Ѿ� �������� ������ ��ġ�� ȸ�������� ����
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            // ������ �Ѿ��� ������ �÷��̾ ���ϵ��� ȸ��
            bullet.transform.LookAt(target);
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
