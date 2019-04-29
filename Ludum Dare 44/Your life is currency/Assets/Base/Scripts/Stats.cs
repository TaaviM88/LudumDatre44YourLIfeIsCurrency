using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField]
    protected float MaxHP = 100;
    protected float currentHp;

    [SerializeField]
    protected float defence = 1;

    [SerializeField]
    protected float maxMoveSpeed = 5;
    
    [SerializeField]
    protected float attackSpeed = 1;

    // Start is called before the first frame update
    void Awake()
    {
        currentHp = MaxHP;
    }


    public void TakeDamage(float dmg)
    {
        //Instantiate hit particle

        float takenDamge = Mathf.Max(currentHp - dmg, 0);
        
        if(takenDamge == 0)
        {
            //Do death stuff here

            Debug.Log($"{gameObject.name} died");
        }
        else
        {
            currentHp -= dmg;
            Debug.Log(currentHp);
        }
    }

    public void RestoreHP(float amount)
    {
        float healAmount = Mathf.Min(currentHp + amount, MaxHP);

        if(healAmount >= MaxHP)
        {
            currentHp = MaxHP;
        }
        else
        {
            currentHp += amount;
        }
    }

}
