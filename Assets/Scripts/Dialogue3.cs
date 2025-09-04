using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Dialogue3 : MonoBehaviour
{
    public Text dialogueText;             // �Ի�������
    public string[] dialogueLines;        // ���жԻ�����
    public GameObject confirmationPanel;  // ȷ�϶Ի���
    public Button yesButton;              // �ǰ�ť
    public Button noButton;               // ��ť

    private int currentLineIndex = 0;

    void Start()
    {
        // ��ʼ����ȷ�϶Ի���
        confirmationPanel.SetActive(false);

        // �󶨰�ť�¼�
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
            // �Ի���������ʾȷ�϶Ի���
            ShowConfirmationDialog();
        }
    }

    private void ShowConfirmationDialog()
    {
        // ��ʾȷ�϶Ի���
        confirmationPanel.SetActive(true);

        // ��ѡ����Ӷ���Ч��
        confirmationPanel.transform.localScale = Vector3.zero;
        confirmationPanel.transform.DOScale(Vector3.one, 0.3f).SetEase(Ease.OutBack);
    }

    private void OnYesClicked()
    {
        // ʹ�ó������Ƽ�����һ������
        SceneManager.LoadScene("EndScene");
    }

    private void OnNoClicked()
    {
        // ʹ�ó������Ƽ�����һ������
        SceneManager.LoadScene("Mainscene");
    }

    // ��ѡ�����һ������������ȷ�϶Ի���
    public void HideConfirmationDialog()
    {
        confirmationPanel.transform.DOScale(Vector3.zero, 0.2f).SetEase(Ease.InBack)
            .OnComplete(() => confirmationPanel.SetActive(false));
    }
}