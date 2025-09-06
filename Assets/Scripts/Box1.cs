using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Box1 : MonoBehaviour
{
    public GameObject passwordPanel;   // 输入密码的界面
    public InputField passwordInput;   // 输入框
    public Text hintText;              // 提示文字
    public GameObject dialogPanel;     // 对话框（提示结果）
    public Text dialogText;            // 对话框文字
    public GameObject key;          // 钥匙（UI元素的话用RectTransform）
    public GameObject key2;
    private string correctPassword = "2684"; // 正确密码

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
            hintText.text = "4位数密码";
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

            // 钥匙动画移动到左上角
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
        // 使用DoTween的回调函数在动画结束后禁用钥匙对象
        key.transform.DOMove(new Vector3(-8, 4, 0), 2f).OnComplete(() => {
            key.SetActive(false);
            key2.SetActive(true);
        });
    }


}
