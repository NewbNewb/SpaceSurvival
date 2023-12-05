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

    public static GameManagerJihu I;

    // �̱���
    void Awake()
    {
        I = this;
    }

    // �ٽ� ���۵Ǹ� �ð��� ������ �Ѵ�
    void Start()
    {
        Time.timeScale = 1.0f; // ���̳ʽ��� 0���� ó���ȴ�
    }

    private void Update()
    {
        if (isRunning) // ���ӽ��� �߿� �ð��� ����
        {
            UpdateTime();
        }
    }

    private string UpdateTime()
    {
        // Ÿ�̸� ǥ��
        time += Time.deltaTime;
        int hour = (int)time / 3600;
        int min = (int)time % 3600 / 60;
        int sec = (int)time % 3600 % 60;
        timeTxt.text = string.Format("{0:D2}:{1:D2}:{2:D2}", hour, min, sec);
        return timeTxt.text;
    }

    // ���ӿ��� ���� �� GameManagerJihu.I.gameOver() ȣ��
    public void GameOver()
    {
        isRunning = false; // �ð� ���߱�
        Time.timeScale = 0f;
        endPanel.SetActive(true);

        // ���ӿ��� �ð��� ���� �ð��� �ߵ���
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
        // Ÿ�̸� ǥ��
        float time = bestScore;
        int hour = (int)time / 3600;
        int min = (int)time % 3600 / 60;
        int sec = (int)time % 3600 % 60;
        timeTxt.text = string.Format("{0:D2}:{1:D2}:{2:D2}", hour, min, sec);
        return timeTxt.text;
    }



}
