using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnManager : MonoBehaviour
{
    // retry ��ư�� ������ ���� ���� �ٽ� �ε�ǵ��� �Ѵ�
    public void GameStart()
    {
        SceneManager.LoadScene("MainGame");
    }

    // main ��ư�� ������ ����ȭ���� �θ���
    public void MainTitle()
    {
        SceneManager.LoadScene("FirstTitle");
    }
}
