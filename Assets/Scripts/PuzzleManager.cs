using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public WheelController wheel;
    public int[] correctSectors = { 2, 5, 7 };  // ��ȷ����������
    private int progress = 0;

    public GameObject puzzlePanel;

    void Update()
    {
        if (Input.GetMouseButtonUp(0)) // �ɿ����ʱ���
        {
            int sector = wheel.GetCurrentSector();
            Debug.Log("��ǰ����" + sector);
            if (sector == correctSectors[progress])
            {
                progress++;
                Debug.Log("��ȷ�����ȣ�" + progress);
                if (progress >= correctSectors.Length)
                {
                    OnPuzzleSolved();
                }
            }
            else
            {
                Debug.Log("��������");
                progress = 0;
            }
        }
    }

    private void OnPuzzleSolved()
    {
        Debug.Log("�����ɹ���");
        GameStatus.isinner3Open=true;
        puzzlePanel.SetActive(false);
        // ��ת����
        UnityEngine.SceneManagement.SceneManager.LoadScene("Red4");
    }
}
