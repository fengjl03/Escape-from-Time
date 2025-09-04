using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // ������������ʹ��UI���

public class WhiteDoors : MonoBehaviour
{
    public int time;
    public GameObject lockedMessageUI;
    private bool open1;
    private bool open2;
    private bool open3;

    /// <summary>
    /// ����Ž�����һ����
    /// </summary>
    private void OnMouseDown()
    {
        time = ClockController.Instance.time;
        open1 = GameStatus.isWhite1Open;
        open2 = GameStatus.isWhite2Open;
        open3 = GameStatus.isWhite3Open;

        ///�жϵ�ǰʱ�䣬��Ҫ����
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
            Text messageText = lockedMessageUI.GetComponent<Text>(); // ��ȡText���
            if (messageText != null)
            {
                messageText.text = message; // �޸��ı�����
                lockedMessageUI.SetActive(true); // ��ʾ�ı�

                CancelInvoke(nameof(HideMessage));
                Invoke(nameof(HideMessage), 2f); // 2����Զ�����
            }
        }
    }

    void HideMessage()
    {
        lockedMessageUI.SetActive(false);
    }
}
