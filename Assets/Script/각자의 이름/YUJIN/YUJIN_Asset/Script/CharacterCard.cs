using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCard : MonoBehaviour
{
    [SerializeField] private List<Character> characters; // CharacterClass를 리스트로 관리

    // Instance화 할 캐릭터 프리팹
    [SerializeField] private RectTransform selectCardTrans;
    [SerializeField] private CharacterSelectCard selectCardPrefab;

    private void Start()
    {
        Character defaultCharacter = characters[0];
        GameManager.Instance.CharacterController = defaultCharacter.animator; // 기본 캐릭 Controller GameManager로 할당  
        GameManager.Instance.CharacterType = defaultCharacter.characterType; // 기본 캐릭 타입 GameManager로 할당  
        GameManager.Instance.CharacterThumbnail = defaultCharacter.characterImage; // 기본 캐릭 이미지 GameManager로 할당  
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

// [캐릭터 정보 셋팅] 직렬화 된 캐릭터 정보를 클래스로 만들어 해당 객체를 리스트로 관리
[Serializable]public class Character
{
    public enum CharacterTypes { character01, character02 } // 캐릭터 타입
    public CharacterTypes characterType; // 고유 타입값
    public Sprite charcterImg; // 캐릭터 스프라이트
    public AnimatorController animator; // 인게임에 사용할 컨트롤러
}

