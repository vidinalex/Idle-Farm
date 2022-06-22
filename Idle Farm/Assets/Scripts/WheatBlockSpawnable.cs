using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheatBlockSpawnable : MonoBehaviour
{
    [SerializeField] private string gatherAreaTag = "GatherArea", characterTag = "Character";
    [SerializeField] private Rigidbody rb;
    [SerializeField] float initialForceStrength, yForceStrength, speed, lifetime = 10f;

    private GameObject target;
    private bool collected = false, isEnabled = false;
    private CharaController charaController;

    private IEnumerator ExecuteAfterTime(float timeInSec)
    {
        yield return new WaitForSeconds(timeInSec);
        isEnabled = true;
    }

    private IEnumerator DieAfterTime(float timeInSec)
    {
        yield return new WaitForSeconds(timeInSec);
        Destroy(gameObject);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.AddForce(
            Random.Range(0, initialForceStrength),
            yForceStrength,
            Random.Range(0, initialForceStrength));

        StartCoroutine(ExecuteAfterTime(1f));
        StartCoroutine(DieAfterTime(lifetime));
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == gatherAreaTag)
        {
            charaController = col.GetComponentInParent<CharaController>();
            if (!isEnabled) return;

            collected = true;
            target = col.gameObject; 
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isEnabled) return;
        if (charaController.IsFull()) return;

        if (collision.gameObject.tag == characterTag)
        {
            charaController.Collect();
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (!collected) return;
        if (charaController.IsFull()) return;

        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
}
