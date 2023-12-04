using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputText : MonoBehaviour
{
    private Canvas _inputPanel;
    [SerializeField] private Button entranceBtn;
    [SerializeField] private TextMeshProUGUI characterName;

    private void Awake()
    {
        _inputPanel = GetComponent<Canvas>();
        entranceBtn.onClick.AddListener(ClosePanel);
        entranceBtn.interactable = false;
    }

    private void Start()
    {
        _inputPanel.gameObject.SetActive(true);
    }

    private void ClosePanel()
    {
        _inputPanel.gameObject.SetActive(false);
    }

    public void OnInputFieldEndEdit(string value)
    {
        characterName.text = value;
        entranceBtn.interactable = (value.Length >= 2 && value.Length < 10) ? true : false;
    }

}
