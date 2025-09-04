using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public WheelController wheel;
    public int[] correctSectors = { 2, 5, 7 };  // 正确的三个区域
    private int progress = 0;

    public GameObject puzzlePanel;

    void Update()
    {
        if (Input.GetMouseButtonUp(0)) // 松开鼠标时检查
        {
            int sector = wheel.GetCurrentSector();
            Debug.Log("当前区域：" + sector);
            if (sector == correctSectors[progress])
            {
                progress++;
                Debug.Log("正确，进度：" + progress);
                if (progress >= correctSectors.Length)
                {
                    OnPuzzleSolved();
                }
            }
            else
            {
                Debug.Log("错误，重置");
                progress = 0;
            }
        }
    }

    private void OnPuzzleSolved()
    {
        Debug.Log("解锁成功！");
        GameStatus.isinner3Open=true;
        puzzlePanel.SetActive(false);
        // 跳转场景
        UnityEngine.SceneManagement.SceneManager.LoadScene("Red4");
    }
}
