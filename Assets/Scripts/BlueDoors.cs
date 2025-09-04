using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BlueDoors : MonoBehaviour
{

    public int time;
    public GameObject lockedMessageUI;

    /// <summary>
    /// 点击门进入下一场景
    /// </summary>
    private void OnMouseDown()
    {

        time=ClockController.Instance.time;
        Debug.Log(GameStatus.key2);
        switch (time)
           
        {
            case 0:
                ShowLockedMessage();
                break;
            case 1:
                if (GameStatus.key2)
                {
                    if (GameStatus.isBlue3Open)
                    {
                        SceneManager.LoadScene("Blue3");
                    }
                    else
                    {
                        Keys keys = FindObjectOfType<Keys>();
                        keys.OpenBlue3();
                    }

                }
                else { ShowLockedMessage(); }
                break;
            case 2:
                SceneManager.LoadScene("Blue1");

                break;
            case 3:
                if (GameStatus.key5)
                {
                    if (GameStatus.isBlue5Open)
                    {
                        SceneManager.LoadScene("Blue5");
                    }
                    else
                    {
                        Keys keys = FindObjectOfType<Keys>();
                        keys.OpenBlue5();
                        
                    }

                }
                else { ShowLockedMessage(); }
                break;
        }
    }

    void ShowLockedMessage()
    {
        if (lockedMessageUI != null)
        {
            lockedMessageUI.SetActive(true);
            CancelInvoke(nameof(HideLockedMessage));
            Invoke(nameof(HideLockedMessage), 2f); // 2秒后自动隐藏
        }
    }
    void HideLockedMessage()
    {
        lockedMessageUI.SetActive(false);
    }
}
