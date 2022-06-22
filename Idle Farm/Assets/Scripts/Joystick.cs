using UnityEngine;
using System.Collections;

public class Joystick : MonoBehaviour
{
    [SerializeField] private GameObject circle, stick;
    [SerializeField] private float stickDistance;

    private Touch touch;
    private RectTransform circleRect, stickRect;
    private Vector2 startTouchPos;
    private bool phaseBegan = false;

    void Awake()
    {
        circleRect = circle.GetComponent<RectTransform>();
        stickRect = stick.GetComponent<RectTransform>();
    }

    void OnGUI()
    {
        if (phaseBegan)
        {
            circle.SetActive(true);
            stick.SetActive(true);
        }
        else
        {
            circle.SetActive(false);
            stick.SetActive(false);
        }
    }

    void Update()
    {
        // Handle screen touches.
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startTouchPos = touch.position;

                phaseBegan = true;

                circleRect.position = touch.position;
                stickRect.position = touch.position;
            }

            if (touch.phase == TouchPhase.Moved)
            {
                float distance = Vector2.Distance(startTouchPos, touch.position);

                stickRect.position = touch.position;

                if (distance > stickDistance)
                {
                    Vector2 fromOriginToObject = touch.position - startTouchPos;
                    fromOriginToObject *= stickDistance / distance;
                    stickRect.position = startTouchPos + fromOriginToObject;
                }
            }

            if(touch.phase == TouchPhase.Ended)
            {
                phaseBegan = false;
            }
        }
    }

    public Vector2 GetVectorNormallized()
    {
        if(phaseBegan)
        return (touch.position - startTouchPos).normalized;

        return Vector2.zero;
    }
}