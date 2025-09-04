using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class InnerDoor : MonoBehaviour
{
    public GameObject passwordPanel;    // �������
    public InputField passwordInput;    // �����
    public Text feedbackText;           // ��ʾ�ı�
    

    private string correctPassword = "369";  // ��ȷ����

    void Start()
    {
        passwordPanel.SetActive(false);
        feedbackText.text = "";
    }

    // �����ʱ����
    private void OnMouseDown()
    {   
        Debug.Log("Inner Door Clicked");
        if (!GameStatus.isinner1Open)
        {
            passwordPanel.SetActive(true);
            passwordInput.text = "";
            feedbackText.text = "Coins";
        }
        else
        {
            SceneManager.LoadScene("Red2");
        }
        
    }

    // �����ťʱ���������ڰ�ť�ϣ�
    public void OnConfirmClicked()
    {
        if (passwordInput.text == correctPassword)
        {
            feedbackText.text = "Door is opened.";
            
            GameStatus.isinner1Open = true;
            SceneManager.LoadScene("Red2");
        }
        else
        {
            feedbackText.text = "Wrong password.";
            passwordInput.text = "";
        }
    }
}
