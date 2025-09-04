using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // ������л�����

public class InnerDoors4 : MonoBehaviour
{
    public GameObject puzzlePanel;   // ����UI
    public Button[] buttons;         // �����ť
    public int[] correctCode = { 1, 3, 5, 2, 4 };  // ��ȷ��
    private int[] currentCode = new int[5];      // ��ҵ�ǰ����

    

    void Start()
    {
        // ��ʼ����ť����¼�
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // ��ֹ�հ�����
            currentCode[i] = 1; // ��ʼ��ʾ 1
            buttons[i].GetComponentInChildren<Text>().text = "1";

            buttons[i].onClick.AddListener(() => OnButtonClick(index));
        }

        puzzlePanel.SetActive(false); // Ĭ�Ϲر�
    }

    void OnButtonClick(int index)
    {
        // ��������������5�ͻص�1
        currentCode[index]++;
        if (currentCode[index] > 5) currentCode[index] = 1;

        // ������ʾ
        buttons[index].GetComponentInChildren<Text>().text = currentCode[index].ToString();

        // ����Ƿ����
        CheckCode();
    }

    void CheckCode()
    {
        for (int i = 0; i < correctCode.Length; i++)
        {
            if (currentCode[i] != correctCode[i]) return;
        }

        // �������ȷ
        UnlockDoor();
    }

    void UnlockDoor()
    {
        GameStatus.isinner4Open = true;

        Debug.Log("���ѽ�����");

        // �رս��ս���
        puzzlePanel.SetActive(false);

        // ����д�ŵĴ�Ч�� �� �л�����
        // ���磺�л�����
        SceneManager.LoadScene("Blue4");
    }

    // �����ʱ�����������
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
