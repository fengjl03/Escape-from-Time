using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void ExitGame()
    {
        // �ڱ༭���в����˳���ֻ�ڹ������Ӧ������Ч
        Application.Quit();

        // ���ڱ༭���еĵ��ԣ�����ʹ�����´���
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}