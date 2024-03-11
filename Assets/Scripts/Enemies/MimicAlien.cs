using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicAlien : Enemy
{

    [Header("Mimic")]
    [SerializeField] GameObject trueForm;
    [SerializeField] GameObject falseForm;

    [Header("Attributes")]
    private bool IsInTrueForm;

    private void Start()
    {
        SetForm();
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
                IsInTrueForm = true;

                if (IsInTrueForm)
                {
                    MoveTowardsPlayer();
                }
            }
        }
    }

    private void SetForm()
    {
        trueForm.SetActive(false);
        falseForm.SetActive(true);
        IsInTrueForm = false;
    }
}