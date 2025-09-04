using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // 如果是切换场景

public class InnerDoors4 : MonoBehaviour
{
    public GameObject puzzlePanel;   // 解谜UI
    public Button[] buttons;         // 五个按钮
    public int[] correctCode = { 1, 3, 5, 2, 4 };  // 正确答案
    private int[] currentCode = new int[5];      // 玩家当前输入

    

    void Start()
    {
        // 初始化按钮点击事件
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // 防止闭包问题
            currentCode[i] = 1; // 初始显示 1
            buttons[i].GetComponentInChildren<Text>().text = "1";

            buttons[i].onClick.AddListener(() => OnButtonClick(index));
        }

        puzzlePanel.SetActive(false); // 默认关闭
    }

    void OnButtonClick(int index)
    {
        // 数字自增，超过5就回到1
        currentCode[index]++;
        if (currentCode[index] > 5) currentCode[index] = 1;

        // 更新显示
        buttons[index].GetComponentInChildren<Text>().text = currentCode[index].ToString();

        // 检查是否解锁
        CheckCode();
    }

    void CheckCode()
    {
        for (int i = 0; i < correctCode.Length; i++)
        {
            if (currentCode[i] != correctCode[i]) return;
        }

        // 如果都正确
        UnlockDoor();
    }

    void UnlockDoor()
    {
        GameStatus.isinner4Open = true;

        Debug.Log("门已解锁！");

        // 关闭解谜界面
        puzzlePanel.SetActive(false);

        // 这里写门的打开效果 或 切换房间
        // 例如：切换场景
        SceneManager.LoadScene("Blue4");
    }

    // 点击门时调用这个函数
    public void OpenPuzzle()
    {
        puzzlePanel.SetActive(true);
    }
    private void OnMouseDown()
    {
        if (GameStatus.isinner4Open) SceneManager.LoadScene("Blue4");
        else OpenPuzzle();
    }
}
