using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PasswordPanel : MonoBehaviour
{
    public InputField passwordInput; // �����
    public Text hintText;            // ��ʾ�ı�
    public string correctPassword = "129518"; // ��ȷ����
    private string currentInput = "";
    public GameObject key;
    public GameObject key2;
    public GameObject dialogPanel;
    public Text dialogText;

    private void OnEnable()
    {
        // �򿪽���ʱ���
        currentInput = "";
        passwordInput.text = "";
        hintText.text = "������6λ����";
    }

    // ���ְ�ť���ô˷���
    public void OnNumberButtonClick(string number)
    {
        if (currentInput.Length >= 6) return; // ���6λ
        currentInput += number;
        passwordInput.text = currentInput;
    }

    // �˸��
    public void OnDeleteButtonClick()
    {
        if (currentInput.Length > 0)
        {
            currentInput = currentInput.Substring(0, currentInput.Length - 1);
            passwordInput.text = currentInput;
        }
    }

    // ȷ�ϼ�
    public void OnConfirmButtonClick()
    {
         if (currentInput == correctPassword)
        {
            hintText.text = "������ȷ��";
            // TODO: ��������ӽ����߼�������/���䶯���ȣ�
            GameStatus.key6 = true;
            MoveKeyToTopLeft();
            ShowDialog("Get the key for the white door on 3:00");
            // �رս���
            
        }
        else
        {
            hintText.text = "�������������";
            // �������
            currentInput = "";
            passwordInput.text = "";
        }
    }
    void MoveKeyToTopLeft()
    {
        // ʹ��DoTween�Ļص������ڶ������������Կ�׶���
        key.transform.DOMove(new Vector3(-8, 4, 0), 2f).OnComplete(() => {
            key.SetActive(false);
            key2.SetActive(true);
        });
    }
    public void ShowDialog(string message)
    {
        dialogPanel.SetActive(true);
        dialogText.text = message;
        StartCoroutine(HideDialogAfterSeconds(2f));
    }

    IEnumerator HideDialogAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        dialogPanel.SetActive(false);
        gameObject.SetActive(false);
    }
}
