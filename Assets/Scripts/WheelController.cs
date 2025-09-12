using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening; // 如果用 DOTween

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
        // 获取当前扇区
        int sector = GetCurrentSector();

        // 算出该扇区的中心角度
        float targetAngle = GetSectorCenterAngle(sector);

        // 使用 DOTween 平滑旋转到中心
        wheel.DORotate(new Vector3(0, 0, targetAngle), 0.3f, RotateMode.Fast);
    }

    public int GetCurrentSector()
    {
        float angle = wheel.eulerAngles.z;
        angle -= 90f; // 基准调整到正上方
        float normalized = (angle % 360 + 360) % 360;
        return Mathf.FloorToInt((normalized + 22.5f) / 45f) % 8;
    }

    public float GetSectorCenterAngle(int sector)
    {
        // 每个扇区宽 45°，中心 = 扇区起始 + 22.5
        float center = sector * 45f ;

        // 转回 Unity 旋转系 (右边为0°，上方为90°)
        return (center + 90f) % 360f;
    }
}
