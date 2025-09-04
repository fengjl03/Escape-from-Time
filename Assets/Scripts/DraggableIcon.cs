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

        // ������ Canvas ���㣬���ⱻ�ڵ�
        transform.SetParent(parentAfterDrag.parent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // �Ż�ԭ��������
        transform.SetParent(parentAfterDrag);

        // �������λ�þ����µ�˳��
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

        // ����˳����
        parentAfterDrag.GetComponent<PuzzleChecker>().CheckOrder();
    }
}
