using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Reddoors : MonoBehaviour
{

    public int time;
    public GameObject lockedMessageUI;

    /// <summary>
    /// 点击门进入下一场景
    /// </summary>
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            time = ClockController.Instance.time;
            
            ///判断当前时间，需要引用
            switch (time)
               
            {
                case 0:
                    ShowLockedMessage();
                    break;
                case 1:
                SceneManager.LoadScene("Red1");
                break;
            case 2:
                    if (GameStatus.key1) 
                    { 
                        if (GameStatus.isRed3Open)
                        {
                            SceneManager.LoadScene("Red3");
                        }
                        else
                        {
                            Keys keys = FindObjectOfType<Keys>();
                            keys.OpenRed3();
                        }
                    
                    }
                else { ShowLockedMessage(); }
                break;
            case 3:
                    if (GameStatus.key4)
                    {
                        if (GameStatus.isRed5Open)
                        {
                            SceneManager.LoadScene("Red5");
                        }
                        else
                        {
                            Keys keys = FindObjectOfType<Keys>();
                            keys.OpenRed5();
                                                    }

                    }
                    else { ShowLockedMessage(); }
                    break;
            }
            
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
