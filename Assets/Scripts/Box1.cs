using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Box1 : MonoBehaviour
{
    public GameObject passwordPanel;   // ��������Ľ���
    public InputField passwordInput;   // �����
    public Text hintText;              // ��ʾ����
    public GameObject dialogPanel;     // �Ի�����ʾ�����
    public Text dialogText;            // �Ի�������
    public GameObject key;          // Կ�ף�UIԪ�صĻ���RectTransform��
    public GameObject key2;
    private string correctPassword = "2684"; // ��ȷ����

    void Start()
    {
        if (GameStatus.key2)
        {
            key.SetActive(false);
            if (!GameStatus.isRed3Open)
            {
                key2.SetActive(true);
            }
        }
    }

    void OnMouseDown()
    {
        if (!GameStatus.key2)
        {
            passwordPanel.SetActive(true);
            hintText.text = "4λ������";
            passwordInput.text = "";
        }
        else
        {
            ShowDialog("You already have the key.");
        }
    }

    public void OnConfirmPassword()
    {
        if (passwordInput.text == correctPassword)
        {
            passwordPanel.SetActive(false);
            ShowDialog("Get a key for the blue door on 3:00.");
            GameStatus.key2 = true;

            // Կ�׶����ƶ������Ͻ�
            MoveKeyToTopLeft();
        }
        else
        {
            hintText.text = "Wrong password.";
        }
    }

    void ShowDialog(string message)
    {
        dialogPanel.SetActive(true);
        dialogText.text = message;
        StartCoroutine(HideDialogAfterSeconds(2f));
    }

    IEnumerator HideDialogAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        dialogPanel.SetActive(false);
    }

    public void CloseDialog()
    {
        dialogPanel.SetActive(false);
        StopAllCoroutines();
    }

    void MoveKeyToTopLeft()
    {
        // ʹ��DoTween�Ļص������ڶ������������Կ�׶���
        key.transform.DOMove(new Vector3(-8, 4, 0), 2f).OnComplete(() => {
            key.SetActive(false);
            key2.SetActive(true);
        });
    }


}
