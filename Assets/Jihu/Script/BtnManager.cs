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
        Debug.Log("���� ����");
    }

    // main ��ư�� ������ ����ȭ���� �θ���
    public void mainTitle()
    {
        SceneManager.LoadScene("FirstTitle");
        Debug.Log("Ÿ��Ʋ");
    }
}
