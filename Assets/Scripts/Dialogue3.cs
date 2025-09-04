using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Dialogue3 : MonoBehaviour
{
    public Text dialogueText;             // 对话框文字
    public string[] dialogueLines;        // 所有对话内容
    public GameObject confirmationPanel;  // 确认对话框
    public Button yesButton;              // 是按钮
    public Button noButton;               // 否按钮

    private int currentLineIndex = 0;

    void Start()
    {
        // 初始隐藏确认对话框
        confirmationPanel.SetActive(false);

        // 绑定按钮事件
        yesButton.onClick.AddListener(OnYesClicked);
        noButton.onClick.AddListener(OnNoClicked);

        if (dialogueLines.Length > 0)
        {
            dialogueText.text = dialogueLines[0];
        }
    }

    public void OnDialogueClick()
    {
        currentLineIndex++;

        if (currentLineIndex < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[currentLineIndex];
        }
        else
        {
            // 对话结束后显示确认对话框
            ShowConfirmationDialog();
        }
    }

    private void ShowConfirmationDialog()
    {
        // 显示确认对话框
        confirmationPanel.SetActive(true);

        // 可选：添加动画效果
        confirmationPanel.transform.localScale = Vector3.zero;
        confirmationPanel.transform.DOScale(Vector3.one, 0.3f).SetEase(Ease.OutBack);
    }

    private void OnYesClicked()
    {
        // 使用场景名称加载下一个场景
        SceneManager.LoadScene("EndScene");
    }

    private void OnNoClicked()
    {
        // 使用场景名称加载上一个场景
        SceneManager.LoadScene("Mainscene");
    }

    // 可选：添加一个方法来隐藏确认对话框
    public void HideConfirmationDialog()
    {
        confirmationPanel.transform.DOScale(Vector3.zero, 0.2f).SetEase(Ease.InBack)
            .OnComplete(() => confirmationPanel.SetActive(false));
    }
}