using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stock : MonoBehaviour
{

    [SerializeField]
    private string stockName;
    //HP
    public float saleValue;
    //AttackPower
    public float buyValue;
    //Defence
    public float changeValue;
    //MoneyPower
    private float stockValue;

    private float changePercent;

    // Start is called before the first frame update
    void Start()
    {
        StockAverage(saleValue, buyValue, changeValue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateStockValues(float percent)
    {
        
    }

    public string ReturnStockName()
    {
        return stockName;
    }

    public float ReturnSaleValue()
    {
        return saleValue;
    }

    public float ReturnBuyValue()
    {
        return buyValue;
    }

    public float ReturnChangeValue()
    {
        return changeValue;
    }

    public void StockAverage(float sale, float buy, float change)
    {
        stockValue = 3 / (sale + buy + change);
    }

    public float ReturnStockValue()
    {
        return stockValue;
    }
}
