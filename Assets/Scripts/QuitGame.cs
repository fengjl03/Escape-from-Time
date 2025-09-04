using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void ExitGame()
    {
        // 在编辑器中不会退出，只在构建后的应用中有效
        Application.Quit();

        // 对于编辑器中的调试，可以使用以下代码
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}