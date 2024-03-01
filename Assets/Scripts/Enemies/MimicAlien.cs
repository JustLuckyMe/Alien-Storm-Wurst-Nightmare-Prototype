using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicAlien : Enemy
{

    [Header("Mimic")]
    [SerializeField] GameObject trueForm;
    [SerializeField] GameObject falseForm;



    private void Start()
    {
        trueForm.SetActive(false);
        falseForm.SetActive(true);
    }
    protected override void DetectAndAct()
    {
        if (target != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, target.position);
            if (distanceToPlayer <= detectionRange)
            {
                trueForm.SetActive(true);
                falseForm.SetActive(false);
            }
        }
    }
}