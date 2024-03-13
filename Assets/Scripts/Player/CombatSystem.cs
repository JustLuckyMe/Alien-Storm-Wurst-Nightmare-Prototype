using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    private Animator anim;
    WeaponManager weaponManager;
    WeaponManager.WeaponType weaponType;

    //bools
    private bool isDrill;


    public static int noOfClicks = 0;
    float lastClickedTime = 0;
    [SerializeField] float maxComboDelay = 0.3f;


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
}
