using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    private Animator anim;
    public float nextFireTime = 2f;
    public static int noOfClicks = 0;
    float lastClickedTime = 0;
    float maxComboDelay = 1;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("MutantPunch_1"))
        {
            anim.SetBool("hit1", false);
        }
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("MutantPunch_2"))
        {
            anim.SetBool("hit2", false);
        }
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("MutantPunch_3"))
        {
            anim.SetBool("hit3", false);
            noOfClicks = 0;
        }

        if (Time.time - lastClickedTime > maxComboDelay)
        {
            noOfClicks = 0;
        }
        if(Time.time > nextFireTime)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                OnPress();
            }
        }
        Debug.Log(noOfClicks);
    }

    void OnPress()
    {
        lastClickedTime = Time.time;
        noOfClicks++;

        if (noOfClicks == 1)
        {
            anim.SetBool("hit1", true);
        }
        noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);

        if (noOfClicks >= 2 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("MutantPunch_1"))
        {
            anim.SetBool("hit1", false);
            anim.SetBool("hit2", true);
        }
        else if (noOfClicks >= 3 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("MutantPunch_2"))
        {
            anim.SetBool("hit2", false);
            anim.SetBool("hit3", true);
        }
    }

}
