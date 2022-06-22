using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaController : MonoBehaviour
{
    [SerializeField] private string awayAreaTag = "AwayArea";
    [SerializeField] private Joystick joystick;
    [SerializeField] private AwayArea awayArea;
    [SerializeField] private ScoreAndUI scoreAndUI;
    [SerializeField] private HarvestAnimArea harvestAnimArea;
    [SerializeField] private float speed, harvestSpeed;
    [SerializeField] private int maxBlocks = 40;
    [SerializeField] private List<GameObject> gatherSpotBlocks;
    [SerializeField] private GameObject scythe;

    private float realSpeed;
    private int currentBlocks = 0;
    private Rigidbody rb;

    private void Start()
    {
        realSpeed = speed;
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (harvestAnimArea.GetIsHarvesting())
        {
            scythe.SetActive(true);
            realSpeed = harvestSpeed;
        }
        else
        {
            scythe.SetActive(false);
            realSpeed = speed;
        }
        Vector2 stickVector = joystick.GetVectorNormallized();
        Vector3 targetVector = new Vector3(-stickVector.x,0,-stickVector.y);

        rb.velocity = realSpeed * Time.deltaTime * targetVector;
        if(targetVector!=Vector3.zero)
        transform.rotation = Quaternion.LookRotation(targetVector);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == awayAreaTag)
        {
            awayArea.InitiateFly(currentBlocks);
            ResetCollected();
        }
    }

    private void ResetCollected()
    {
        currentBlocks = 0;
        foreach(GameObject go in gatherSpotBlocks)
        {
            go.SetActive(false);
        }
        scoreAndUI.UpdateCarryLimit(currentBlocks);
    }

    public bool IsFull()
    {
        if(currentBlocks<maxBlocks)
            return false;
        return true;
    }

    public void Collect()
    {
        if (currentBlocks >= maxBlocks) return;

        currentBlocks++;
        gatherSpotBlocks[currentBlocks-1].SetActive(true);
        scoreAndUI.UpdateCarryLimit(currentBlocks);
    }

}
