using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class InnerDoor2 : MonoBehaviour
{
    public GameObject passwordPanel;    // �������
    public InputField passwordInput;    // �����
    public Text feedbackText;           // ��ʾ�ı�
    public bool DoorStatus1 = GameStatus.isinner2Open;

    private string correctPassword = "35412";  // ��ȷ����

    void Start()
    {
        passwordPanel.SetActive(false);
        feedbackText.text = "";
    }

    // �����ʱ����
    private void OnMouseDown()
    {
        if (!DoorStatus1)
        {
            passwordPanel.SetActive(true);
            passwordInput.text = "";
            feedbackText.text = "Fruits";
            
        }
        else
        {
            SceneManager.LoadScene("Blue2");
        }

    }

    // �����ťʱ���������ڰ�ť�ϣ�
    public void OnConfirmClicked()
    {
        if (passwordInput.text == correctPassword)
        {
            feedbackText.text = "Door is opened.";
            
            GameStatus.isinner2Open = true;
        }
        else
        {
            feedbackText.text = "Wrong password.";
            passwordInput.text = "";
        }
    }
}
