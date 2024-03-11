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

    void Update()
    {
        if (Time.time - lastClickedTime > maxComboDelay)
        {
            noOfClicks = 0;
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            lastClickedTime = Time.time;
            noOfClicks++;

            if (noOfClicks == 1)
            {
                anim.SetBool("hit1", true);
            }
            else if (noOfClicks == 2)
            {
                anim.SetBool("hit2", true);
            }
            else if (noOfClicks == 3)
            {
                anim.SetBool("hit3", true);
            }

            noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);
        }
        Debug.Log(noOfClicks);
    }

    /*    void OnPress()
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
                //anim.SetBool("hit1", false);
                anim.SetBool("hit2", true);
            }
            else if (noOfClicks >= 3 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("MutantPunch_2"))
            {
                anim.SetBool("hit2", false);
                anim.SetBool("hit3", true);
            }
        }*/
    public void return1()
    {
        if(noOfClicks >= 2)
        {
            anim.SetBool("hit2", true);
        }
        else
        {
            anim.SetBool("hit1", false);
            noOfClicks = 0;
        }
    }

    public void return2()
    {
        if (noOfClicks >= 3)
        {
            anim.SetBool("hit3", true);
        }
        else
        {
            anim.SetBool("hit2", false);
            noOfClicks = 0;
        }
    }

    public void return3()
    {
        anim.SetBool("hit1", false);
        anim.SetBool("hit2", false);
        anim.SetBool("hit3", false);
        noOfClicks = 0;
    }
}
