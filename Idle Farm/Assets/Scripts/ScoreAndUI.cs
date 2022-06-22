using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreAndUI : MonoBehaviour
{
    [SerializeField] private string animatorBoolName = "isShaking";
    [SerializeField] private int maxCarryLimit = 40, cost = 15, step = 15;
    [SerializeField] TextMeshProUGUI carryLimitText, moneyText;
    [SerializeField] Animator moneyAnimator;

    private int targetMoney = 0;
    
    public void UpdateCarryLimit(int amount)
    {
        carryLimitText.text = amount.ToString() + "/" + maxCarryLimit.ToString();
    }

    public void UpdateMoney(int amount)
    {
        targetMoney += cost * amount;
    }

    private void FixedUpdate()
    {
        int tempMoney = int.Parse(moneyText.text);
        if (tempMoney < targetMoney)
        {
            moneyText.text = (tempMoney+step).ToString();
            moneyAnimator.SetBool(animatorBoolName, true);
        }
        else
        {
            moneyAnimator.SetBool(animatorBoolName, false);
        }
    }
}
