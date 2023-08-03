using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;

    private Transform target;       // 발사대상 -> 플레이어
    private float spawnRate;        // 생성주기
    private float timeAfterSpawn;   //최근 생성시점에서 지난 시간

    void Start()
    {
        // 누적시간 초기화
        timeAfterSpawn = 0f;
        // 생성 간격 랜덤 지정
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        // 플레이어 조준
        target = FindObjectOfType<PlayerController>().transform;
    }

    void Update()
    {
        // timeAfterSpawn 갱신
        timeAfterSpawn += Time.deltaTime;
        if (timeAfterSpawn >= spawnRate)
        {
            // 누적 시간 초기화
            timeAfterSpawn = 0f;
            // 총알 복제본이 스포너 위치와 회전값으로 생성
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            // 생성된 총알의 정면이 플레이어를 향하도록 회전
            bullet.transform.LookAt(target);
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
