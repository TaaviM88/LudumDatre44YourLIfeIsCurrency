using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    [SerializeField]
    protected Transform attackPos;

    [SerializeField]
    protected float attackRange = 1;

    //Layer you want to attack hit.
    [SerializeField]
    protected LayerMask hitLayer;

    [SerializeField]
    protected float damage = 1;

    [SerializeField]
    protected float timeBTWAttacks = 2;
    protected float currentTimeBTWAttack = 0;

    Animator anime;

    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        //Check cooldown
        if(currentTimeBTWAttack <= 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                anime.SetTrigger("Attack");
                Collider2D[] targetToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, hitLayer);
                for (int i = 0; i < targetToDamage.Length; i++)
                {
                    //DO DAMAGE
                    targetToDamage[i].GetComponent<Stats>().TakeDamage(damage);
                }
                currentTimeBTWAttack = timeBTWAttacks;
                
            }
           
        }
        else
        {
            currentTimeBTWAttack -= Time.deltaTime;
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    public void UpdateDamage(float dmg)
    {
        damage = dmg;
    }
}
