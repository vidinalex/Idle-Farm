using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    [SerializeField] private Camera m_Camera;
    [SerializeField] GameObject moneyText, targetArea;

    void Update()
    {
        targetArea.transform.position = m_Camera.ScreenToWorldPoint(new Vector3(
            moneyText.transform.position.x,
            moneyText.transform.position.y,
            5f));
    }
}
