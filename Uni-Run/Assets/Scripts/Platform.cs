using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject[] obstacles;
    private bool stepped = false;

    private void OnEnable()
    {
        // 발판 리셋
        stepped = false;
        for(int i = 0; i<obstacles.Length; i++)
        {
            if (Random.Range(0, 3) == 0)
                obstacles[i].SetActive(true);
            else
                obstacles[i].SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //플레이어가 밟았을 때 점수 추가
        if(collision.collider.tag == "Player" && !stepped)
        {
            stepped=true;
            GameManager.instance.AddScore(1);
        }
    }
}

