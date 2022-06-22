using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    [SerializeField] private string animatorIntName = "State";
    [SerializeField] private Animator animator;
    [SerializeField] private HarvestAnimArea harvestAnimArea;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (harvestAnimArea.GetIsHarvesting())
        {
            animator.SetInteger(animatorIntName, 2);
        } 
        else
        if (rb.velocity != Vector3.zero)
        {
            animator.SetInteger(animatorIntName, 1);
        }
        else
        {
            animator.SetInteger(animatorIntName, 0);
        }
    }
}
