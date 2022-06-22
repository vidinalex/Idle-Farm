using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float maxWaitTime = 0.5f, speed = 5f, lifeTime = 0.5f;


    private Vector3 initialCoords;
    private bool isFlying = false;

    private void Start()
    {
        initialCoords = transform.position;
    }

    private IEnumerator ExecuteAfterTime(float timeInSec)
    {
        yield return new WaitForSeconds(timeInSec);
        isFlying = true;
        StartCoroutine(DieAfterTime(lifeTime));
    }

    private IEnumerator DieAfterTime(float timeInSec)
    {
        yield return new WaitForSeconds(timeInSec);
        transform.position = initialCoords;
        isFlying = false;
        gameObject.SetActive(false);
    }

    public void Fly()
    {
        StartCoroutine(ExecuteAfterTime(Random.Range(0,maxWaitTime)));
    }

    private void FixedUpdate()
    {
        if (!isFlying) return;

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
