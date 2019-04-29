using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : Stats
{

    Attack attack;

    // Start is called before the first frame update
    void Start()
    {
        attack = GetComponent<Attack>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Stock>())
        {
            Debug.Log($"Hey you got {collision.gameObject.GetComponent<Stock>().ReturnStockName()}");
           attack.UpdateDamage(collision.gameObject.GetComponent<Stock>().ReturnBuyValue());
           MaxHP = collision.gameObject.GetComponent<Stock>().ReturnSaleValue();
            defence = collision.gameObject.GetComponent<Stock>().ReturnChangeValue();

            Destroy(collision.gameObject);
        }
    }
}
