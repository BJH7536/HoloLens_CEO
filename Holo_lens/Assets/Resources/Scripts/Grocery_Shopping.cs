using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Grocery_Shopping : MonoBehaviour
{
    // Start is called before the first frame update

    public int tomatoPrice = 1000;
    public int applePrice = 500;
    private int totalPrice = 0;
    public TextMeshPro totalPriceText;


    
    private void OnTriggerEnter(Collider ob) // 계산대에 물건이 들어오면 가격을 더한다.
    {
        if (ob.CompareTag("Apple"))
            Add(ob);
        else if (ob.CompareTag("Tomato"))
            Add(ob);
    }

    private void OnTriggerExit(Collider ob) // 계산대에서 물건이 빠지면 가격을 뺀다.
    {
        if (ob.CompareTag("Apple"))
            Substract(ob);
        else if (ob.CompareTag("Tomato"))
            Substract(ob);
    }

    private void Add(Collider ob) // 가격을 더하고 전체가격을 출력한다.
    {
        if (ob.CompareTag("Apple"))
            totalPrice += applePrice;
        else if (ob.CompareTag("Tomato"))
            totalPrice += tomatoPrice;
        UpdateTotalPrice();
    }

    private void Substract(Collider ob) // 가격을 빼고 전체가격을 출력한다.
    {
        if (ob.CompareTag("Apple"))
            totalPrice -= applePrice;
        else if (ob.CompareTag("Tomato"))
            totalPrice -= tomatoPrice;
        UpdateTotalPrice();
    }
 

    private void UpdateTotalPrice() // 가격을 출력한다.
    {
        totalPriceText.text = "가격:" + totalPrice.ToString("N0") + "원";
    }

}
