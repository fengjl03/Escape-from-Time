using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockController : MonoBehaviour
{
    public static ClockController Instance { get; private set; }

    public Transform minuteHand;
    public Transform hourHand;

    public int time;

    private bool isDragging = false;
    private float currentTimeInMinutes = -180f; // 从3:00开始，3*60 = 180分钟
    private float lastAngle;

    private void Start()
    {

    }

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        HandleInput();
        UpdateHands();
        UpdateTimeState();
    }

    void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (IsPointerNearMinuteHand())
            {
                isDragging = true;
                lastAngle = GetAngleFromMouse();
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            float currentAngle = GetAngleFromMouse();
            float deltaAngle = Mathf.DeltaAngle(lastAngle, currentAngle); // 自动处理跨0/360情况
            float deltaMinutes = deltaAngle / 6f; // 6度 = 1分钟
            currentTimeInMinutes += deltaMinutes;

            lastAngle = currentAngle;
        }
    }

    void UpdateHands()
    {
        float minuteAngle = (currentTimeInMinutes % 60f) * 6f;
        float hourAngle = (currentTimeInMinutes / 60f) * 30f;
        minuteHand.localRotation = Quaternion.Euler(0, 0, minuteAngle);
        hourHand.localRotation = Quaternion.Euler(0, 0, hourAngle);
    }

    void UpdateTimeState()
    {
        float hour = currentTimeInMinutes / 60f;
        Debug.Log(time);
        if (hour >= -3.083f && hour <= -2.916f)
        {
            time = 1;
        }
        else if (hour >= -3.833f && hour <= -3.666f)      // 3:40 - 3:50
        { time = 2; }
        else if (hour >= -5.75f && hour <= -5.58f)   // 5:35 - 5:45
        { time = 3; }
        else if (hour >= -8.833f && hour <= -8.666f)   // 8:40 - 8:50
        { time = 4; }
        else { time = 0; }
    }

    float GetAngleFromMouse()
    {
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = (Vector2)(mouseWorld - transform.position);
        return Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
    }

    bool IsPointerNearMinuteHand()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null)
        {
            // 检查点击的是否是 minuteHand 或其子对象
            return hit.collider.transform.IsChildOf(minuteHand) || hit.collider.transform == minuteHand;
        }

        return false;
    }
}
