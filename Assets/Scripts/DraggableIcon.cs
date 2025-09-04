using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableIcon : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Transform parentAfterDrag;
    private int siblingIndex;
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        siblingIndex = transform.GetSiblingIndex();

        // 提升到 Canvas 顶层，避免被遮挡
        transform.SetParent(parentAfterDrag.parent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // 放回原来的容器
        transform.SetParent(parentAfterDrag);

        // 根据鼠标位置决定新的顺序
        int newIndex = parentAfterDrag.childCount;
        for (int i = 0; i < parentAfterDrag.childCount; i++)
        {
            if (rectTransform.position.x < parentAfterDrag.GetChild(i).position.x)
            {
                newIndex = i;
                break;
            }
        }

        transform.SetSiblingIndex(newIndex);
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        // 调用顺序检查
        parentAfterDrag.GetComponent<PuzzleChecker>().CheckOrder();
    }
}
