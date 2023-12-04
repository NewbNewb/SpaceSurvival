using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCard : MonoBehaviour
{
    [SerializeField] private List<Character> characters; // CharacterClass�� ����Ʈ�� ����

    // Instanceȭ �� ĳ���� ������
    [SerializeField] private RectTransform selectCardTrans;
    [SerializeField] private CharacterSelectCard selectCardPrefab;

    private void Start()
    {
        Character defaultCharacter = characters[0];
        GameManager.Instance.CharacterController = defaultCharacter.animator; // �⺻ ĳ�� Controller GameManager�� �Ҵ�  
        GameManager.Instance.CharacterType = defaultCharacter.characterType; // �⺻ ĳ�� Ÿ�� GameManager�� �Ҵ�  
        GameManager.Instance.CharacterThumbnail = defaultCharacter.characterImage; // �⺻ ĳ�� �̹��� GameManager�� �Ҵ�  
        InstantiateSelectCard();
    }
    private void InstantiateSelectCard()
    {
        foreach (var character in characters)
        {
            CharacterSelectCard cardInstance = Instantiate(selectCardPrefab, selectPanelTransform);
            cardInstance.CharacterType = character.characterType;
            cardInstance.CharacterSprite = character.characterImage;
            cardInstance.Controller = character.animator;
        }
    }
}

// [ĳ���� ���� ����] ����ȭ �� ĳ���� ������ Ŭ������ ����� �ش� ��ü�� ����Ʈ�� ����
[Serializable]public class Character
{
    public enum CharacterTypes { character01, character02 } // ĳ���� Ÿ��
    public CharacterTypes characterType; // ���� Ÿ�԰�
    public Sprite charcterImg; // ĳ���� ��������Ʈ
    public AnimatorController animator; // �ΰ��ӿ� ����� ��Ʈ�ѷ�
}

