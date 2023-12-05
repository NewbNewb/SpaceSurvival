using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerJihu : MonoBehaviour
{
    public TMP_Text timeTxt;
    public TMP_Text currentScoreTxt;
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
            // Ÿ�̸� ǥ��
            time += Time.deltaTime;
            int hour = (int)time / 3600;
            int min = (int)time % 3600 / 60;
            int sec = (int)time % 3600 % 60;
            timeTxt.text = string.Format("{0:D2}:{1:D2}:{2:D2}", hour, min, sec);
        }
    }

    // ���ӿ��� ���� �� GameManagerJihu.I.gameOver() ȣ��
    public void gameOver()
    {
        isRunning = false; // �ð� ���߱�
        Time.timeScale = 0f;
        endPanel.SetActive(true);

        // ���ӿ��� �ð��� ���� �ð��� �ߵ���
        currentScoreTxt.text = timeTxt.text;
    }

    

    
}
