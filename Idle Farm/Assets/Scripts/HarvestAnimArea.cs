using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestAnimArea : MonoBehaviour
{
    [SerializeField] private string ridgeTag = "Ridge";

    private bool isHarvesting = false;
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == ridgeTag)
        {
            isHarvesting = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == ridgeTag)
        {
            isHarvesting = false;
        }
    }

    public bool GetIsHarvesting()
    {
        return isHarvesting;
    }
}
