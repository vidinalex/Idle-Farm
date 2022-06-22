using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwayArea : MonoBehaviour
{
    [SerializeField] private float delay = 0.4f;
    [SerializeField] private ScoreAndUI scoreAndUI;
    [SerializeField] private List<GameObject> objWheatBlock;
    [SerializeField] private List<MoveTowards> scrWheatBlock;

    [SerializeField] private List<GameObject> objCoinBlock;
    [SerializeField] private List<MoveTowards> scrCoinBlock;

    private IEnumerator UpdateMoneyAfterTime(float timeInSec, int count)
    {
        yield return new WaitForSeconds(timeInSec);
        scoreAndUI.UpdateMoney(count);
    }

    private void Start()
    {
        scoreAndUI.UpdateMoney(0);
    }

    public void InitiateFly(int count)
    {
        if (count == 0) return;

        StartCoroutine(UpdateMoneyAfterTime(delay, count));
        for (int i = 0; i < count; i++)
        {
            objWheatBlock[i].SetActive(true);
            scrWheatBlock[i].Fly();
        }
        InitiateMoneyFly(count);
    }

    private void InitiateMoneyFly(int count)
    {
        for (int i = 0; i < count; i++)
        {
            objCoinBlock[i].SetActive(true);
            scrCoinBlock[i].Fly();
        }
    }
}
