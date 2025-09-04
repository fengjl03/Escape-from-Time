using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PasswordPanel : MonoBehaviour
{
    public InputField passwordInput; // 输入框
    public Text hintText;            // 提示文本
    public string correctPassword = "129518"; // 正确密码
    private string currentInput = "";
    public GameObject key;
    public GameObject key2;
    public GameObject dialogPanel;
    public Text dialogText;

    private void OnEnable()
    {
        // 打开界面时清空
        currentInput = "";
        passwordInput.text = "";
        hintText.text = "请输入6位密码";
    }

    // 数字按钮调用此方法
    public void OnNumberButtonClick(string number)
    {
        if (currentInput.Length >= 6) return; // 最多6位
        currentInput += number;
        passwordInput.text = currentInput;
    }

    // 退格键
    public void OnDeleteButtonClick()
    {
        if (currentInput.Length > 0)
        {
            currentInput = currentInput.Substring(0, currentInput.Length - 1);
            passwordInput.text = currentInput;
        }
    }

    // 确认键
    public void OnConfirmButtonClick()
    {
         if (currentInput == correctPassword)
        {
            hintText.text = "密码正确！";
            // TODO: 在这里添加解锁逻辑（开门/开箱动画等）
            GameStatus.key6 = true;
            MoveKeyToTopLeft();
            ShowDialog("Get the key for the white door on 3:00");
            // 关闭界面
            
        }
        else
        {
            hintText.text = "密码错误，请重试";
            // 清空输入
            currentInput = "";
            passwordInput.text = "";
        }
    }
    void MoveKeyToTopLeft()
    {
        // 使用DoTween的回调函数在动画结束后禁用钥匙对象
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
