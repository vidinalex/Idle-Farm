using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ridge : MonoBehaviour
{
    [SerializeField] private string scytheTag = "Scythe";
    [SerializeField] private List<GameObject> ridgesStage;
    [SerializeField] private float rebirthTimer = 10f;
    [SerializeField] private GameObject wheatBlock;

    private int stage = 2;

    private IEnumerator ExecuteAfterTime(float timeInSec)
    {
        yield return new WaitForSeconds(timeInSec);
        stage = 2;
        ridgesStage[0].SetActive(false);
        ridgesStage[2].SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (stage == 0) return;

        if(other.tag == scytheTag)
        {
            ridgesStage[stage].SetActive(false);
            stage--;
            ridgesStage[stage].SetActive(true);
            Instantiate(wheatBlock,transform.position,Quaternion.identity);
        }

        if (stage == 0)
        {
            StartCoroutine(ExecuteAfterTime(rebirthTimer));
        }
    }
}
