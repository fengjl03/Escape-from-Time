using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // 添加这个引用以使用UI组件

public class WhiteDoors : MonoBehaviour
{
    public int time;
    public GameObject lockedMessageUI;
    private bool open1;
    private bool open2;
    private bool open3;

    /// <summary>
    /// 点击门进入下一场景
    /// </summary>
    private void OnMouseDown()
    {
        time = ClockController.Instance.time;
        open1 = GameStatus.isWhite1Open;
        open2 = GameStatus.isWhite2Open;
        open3 = GameStatus.isWhite3Open;

        ///判断当前时间，需要引用
        switch (time)
        {
            case 1:
                if (!open3)
                {   
                    if (GameStatus.key6) 
                    {
                        GameStatus.isWhite3Open = true;
                        SceneManager.LoadScene("White3"); 
                    }
                    else { ShowMessage("Locked"); }
                }
                else
                {
                    ShowMessage("Already visited");
                }
                break;
            case 2:
                if (!open2)
                {
                    if (GameStatus.key3) 
                    { 
                        
                        Keys keys = FindObjectOfType<Keys>();
                        keys.OpenWhite2();
                    }
                    else { ShowMessage("Locked"); }
                }
                else
                {
                    ShowMessage("Already visited");
                }
                break;
            case 3:
                if (!open1)
                {
                    GameStatus.isWhite1Open = true;
                    GameStatus.key1 = true;
                    SceneManager.LoadScene("White1");
                }
                else
                {
                    ShowMessage("Already visited");
                }
                break;
            case 0:
                {
                    ShowMessage("Not the right time.");
                    break;
                }
        }

    }
    private void ShowMessage(string message)
    {
        if (lockedMessageUI != null)
        {
            Text messageText = lockedMessageUI.GetComponent<Text>(); // 获取Text组件
            if (messageText != null)
            {
                messageText.text = message; // 修改文本内容
                lockedMessageUI.SetActive(true); // 显示文本

                CancelInvoke(nameof(HideMessage));
                Invoke(nameof(HideMessage), 2f); // 2秒后自动隐藏
            }
        }
    }

    void HideMessage()
    {
        lockedMessageUI.SetActive(false);
    }
}
