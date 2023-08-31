using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameover;
    public Text scoreText;
    public GameObject gameoverUI;

    public int score = 0;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
        {
            Debug.LogWarning("씬에 2개 이상의 게임 매니저가 존재합니다!");
            Destroy(gameObject);
        }
    }
    void Update()
    {
        if(isGameover && Input.GetMouseButtonDown(0))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void AddScore(int newScore)
    {
        if (!isGameover)
        {
            score += newScore;
            scoreText.text = "Score : " + score;
        }
    }
    public void OnPlayerDead()
    {
        isGameover = true;
        gameoverUI.SetActive(true);
    }
}
