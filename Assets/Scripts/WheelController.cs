using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WheelController : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public RectTransform wheel;

    private float startAngle;       // ��갴��ʱ�ĽǶ�
    private float startWheelAngle;  // ���̳�ʼ�Ƕ�

    // ��ק��ʼʱ��¼״̬
    public void OnBeginDrag(PointerEventData eventData)
    {
        Vector2 dir = eventData.position - (Vector2)wheel.position;
        startAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        startWheelAngle = wheel.eulerAngles.z;
    }

    // ��ק�У���������ʼ�ǶȵĲ�ֵ
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 dir = eventData.position - (Vector2)wheel.position;
        float currentAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        float angleOffset = currentAngle - startAngle;
        wheel.rotation = Quaternion.Euler(0, 0, startWheelAngle + angleOffset);
    }

    public int GetCurrentSector()
    {
        float angle = wheel.eulerAngles.z;

        // ������׼�㣺0�� ������Ϸ�
        angle -= 90f;

        // �淶���� 0~360
        float normalized = (angle % 360 + 360) % 360;

        // ÿ������ 45��
        return Mathf.FloorToInt((normalized + 22.5f) / 45f) % 8;
    }
}
