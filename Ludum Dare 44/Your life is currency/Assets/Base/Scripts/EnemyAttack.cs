using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : Attack
{
    

    // Update is called once per frame
    public override void Update()
    {
        if (currentTimeBTWAttack <= 0)
        {
         Collider2D[] targetToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, hitLayer);
            for (int i = 0; i < targetToDamage.Length; i++)
            {
             targetToDamage[i].GetComponent<Stats>().TakeDamage(damage);
            }
             currentTimeBTWAttack = timeBTWAttacks;
        }
        else
        {
            currentTimeBTWAttack -= Time.deltaTime;
        }
        base.Update();
    }
}
