using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class InnerDoor : MonoBehaviour
{
    public GameObject passwordPanel;    // 密码面板
    public InputField passwordInput;    // 输入框
    public Text feedbackText;           // 提示文本
    

    private string correctPassword = "369";  // 正确密码

    void Start()
    {
        passwordPanel.SetActive(false);
        feedbackText.text = "";
    }

    // 点击门时触发
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

    // 点击按钮时触发（挂在按钮上）
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
