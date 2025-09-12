using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening; // ����� DOTween

public class WheelController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public RectTransform wheel;

    private float startAngle;
    private float startWheelAngle;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Vector2 dir = eventData.position - (Vector2)wheel.position;
        startAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        startWheelAngle = wheel.eulerAngles.z;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 dir = eventData.position - (Vector2)wheel.position;
        float currentAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        float angleOffset = currentAngle - startAngle;
        wheel.rotation = Quaternion.Euler(0, 0, startWheelAngle + angleOffset);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // ��ȡ��ǰ����
        int sector = GetCurrentSector();

        // ��������������ĽǶ�
        float targetAngle = GetSectorCenterAngle(sector);

        // ʹ�� DOTween ƽ����ת������
        wheel.DORotate(new Vector3(0, 0, targetAngle), 0.3f, RotateMode.Fast);
    }

    public int GetCurrentSector()
    {
        float angle = wheel.eulerAngles.z;
        angle -= 90f; // ��׼���������Ϸ�
        float normalized = (angle % 360 + 360) % 360;
        return Mathf.FloorToInt((normalized + 22.5f) / 45f) % 8;
    }

    public float GetSectorCenterAngle(int sector)
    {
        // ÿ�������� 45�㣬���� = ������ʼ + 22.5
        float center = sector * 45f ;

        // ת�� Unity ��תϵ (�ұ�Ϊ0�㣬�Ϸ�Ϊ90��)
        return (center + 90f) % 360f;
    }
}
