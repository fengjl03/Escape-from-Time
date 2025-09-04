using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WheelController : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public RectTransform wheel;

    private float startAngle;       // 鼠标按下时的角度
    private float startWheelAngle;  // 轮盘初始角度

    // 拖拽开始时记录状态
    public void OnBeginDrag(PointerEventData eventData)
    {
        Vector2 dir = eventData.position - (Vector2)wheel.position;
        startAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        startWheelAngle = wheel.eulerAngles.z;
    }

    // 拖拽中：计算与起始角度的差值
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

        // 调整基准点：0° 变成正上方
        angle -= 90f;

        // 规范化到 0~360
        float normalized = (angle % 360 + 360) % 360;

        // 每块区域 45°
        return Mathf.FloorToInt((normalized + 22.5f) / 45f) % 8;
    }
}
