using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    private Animator anim;
    WeaponManager weaponManager;
    WeaponManager.WeaponType weaponType;


    public float nextFireTime = 2f;
    public static int noOfClicks = 0;
    float lastClickedTime = 0;
    float maxComboDelay = 1;
    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        weaponManager = GetComponent<WeaponManager>();
    }

    void Update()
    {
        if (weaponManager.currentWeaponType == WeaponManager.WeaponType.Drill) //if weapontype is drill
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
                    anim.SetTrigger("hit1");
                }
                else if (noOfClicks == 2)
                {
                    anim.SetTrigger("hit2");
                }
                else if (noOfClicks == 3)
                {
                    anim.SetTrigger("hit3");
                }

                noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);
            }
        }

        if (weaponManager.currentWeaponType == WeaponManager.WeaponType.Hammer) //if weapontype is hammer
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
                    anim.SetTrigger("hit1");
                }
                else if (noOfClicks == 2)
                {
                    anim.SetTrigger("hit2");
                }
                else if (noOfClicks == 3)
                {
                    anim.SetTrigger("hit3");
                }

                noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);
            }
        }
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
   /* public void return1()
    {
        if (noOfClicks >= 2)
        {
            anim.SetTrigger("hit2");
        }
        else
        {
            Debug.Log("Hi");
            noOfClicks = 0;
        }
            anim.SetTrigger("hit1");
    }

    public void return2()
    {
        if (noOfClicks >= 3)
        {
            anim.SetTrigger("hit3");
        }
        else
        {
            noOfClicks = 0;
        }
            anim.SetTrigger("hit2");
    }

    public void return3()
    {
        anim.SetTrigger("hit1");
        anim.SetTrigger("hit2");
        anim.SetTrigger("hit3");
        noOfClicks = 0;
    }*/
}
