using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManagerJihu : MonoBehaviour
{
    public TMP_Text timeTxt;
    public TMP_Text currentScoreTxt;
    public TMP_Text bestScoreTxt;
    private float time;
    private bool isRunning = true;
    public GameObject endPanel;
    public AudioClip gameOver;
    public AudioSource audioSource;

    public static GameManagerJihu I;

    // 싱글톤
    void Awake()
    {
        I = this;
    }

    // 다시 시작되면 시간이 가도록 한다
    void Start()
    {
        Time.timeScale = 1.0f; // 마이너스는 0으로 처리된다
    }

    private void Update()
    {
        if (isRunning) // 게임실행 중에 시간이 간다
        {
            UpdateTime();
        }
    }

    private string UpdateTime()
    {
        // 타이머 표시
        time += Time.deltaTime;
        int hour = (int)time / 3600;
        int min = (int)time % 3600 / 60;
        int sec = (int)time % 3600 % 60;
        timeTxt.text = string.Format("{0:D2}:{1:D2}:{2:D2}", hour, min, sec);
        return timeTxt.text;
    }

    // 게임오버 됐을 때 GameManagerJihu.I.gameOver() 호출
    public void GameOver()
    {
        audioSource.PlayOneShot(gameOver);
        isRunning = false; // 시간 멈추기
        Time.timeScale = 0f;
        endPanel.SetActive(true);


        // 게임오버 시간이 현재 시간에 뜨도록
        currentScoreTxt.text = timeTxt.text;

        if (PlayerPrefs.HasKey("bestScore") == false)
        {
            PlayerPrefs.SetFloat("bestScore", time);
        }
        else
        {
            if (PlayerPrefs.GetFloat("bestScore") < time)
            {
                PlayerPrefs.SetFloat("bestScore", time);
            }
        }
        float bestScore = PlayerPrefs.GetFloat("bestScore");

        bestScoreTxt.text = BestTimeScore(bestScore);
    }

    private string BestTimeScore(float bestScore)
    {
        // 타이머 표시
        float time = bestScore;
        int hour = (int)time / 3600;
        int min = (int)time % 3600 / 60;
        int sec = (int)time % 3600 % 60;
        timeTxt.text = string.Format("{0:D2}:{1:D2}:{2:D2}", hour, min, sec);
        return timeTxt.text;
    }



}
