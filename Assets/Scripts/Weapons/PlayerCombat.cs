using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public List<AttackSO> combo;
    float lastClickedTime;
    float lastComboEnd;
    int comboCounter;

    Animator anim;
    [SerializeField] Weapon weapon;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Attack()
    {
        if(Time.time - lastComboEnd > 0.2f && comboCounter <= combo.Count)
        {
            CancelInvoke("EndCombo");

            if(Time.time - lastClickedTime >= 0.2)
            {
                anim.runtimeAnimatorController = combo[comboCounter].animatorOV;
                anim.Play("Attack", 0, 0);
                weapon.damage = combo[comboCounter].damage;
                comboCounter++;
                lastClickedTime = Time.time;
                // add here all the vfx and shit like that

                if (comboCounter > combo.Count)
                {
                    comboCounter = 0;
                }
            }
        }
    }

    void ExitAttack()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9 && anim.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            Invoke("EndCombo", 1);
        }
    }

    void EndCombo()
    {
        comboCounter = 0;
        lastComboEnd = Time.time;
        // if the combo ends with an explosion or something here is where you add it.
    }
}
