using Microsoft.MixedReality.Toolkit.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Grocery_Shopping : MonoBehaviour
{
    //가격
    public int tomatoPrice = 1000;
    public int applePrice = 500;
    private int totalPrice = 0;

    public TextMeshPro totalPriceText;
    // 계산대에 물건이 들어오면 가격을 더한다.
    private void OnTriggerEnter(Collider ob)
    {
        if (ob.CompareTag("Apple"))
            Add(ob);
        else if (ob.CompareTag("Tomato"))
            Add(ob);
    }

    // 계산대에서 물건이 빠지면 가격을 뺀다.
    private void OnTriggerExit(Collider ob) 
    {
        if (ob.CompareTag("Apple"))
            Substract(ob);
        else if (ob.CompareTag("Tomato"))
            Substract(ob);
    }

    // 가격을 더하고 전체가격을 출력한다.
    private void Add(Collider ob) 
    {
        if (ob.CompareTag("Apple"))
            totalPrice += applePrice;
        else if (ob.CompareTag("Tomato"))
            totalPrice += tomatoPrice;
        UpdateTotalPrice();
    }

    // 가격을 빼고 전체가격을 출력한다.
    private void Substract(Collider ob) 
    {
        if (ob.CompareTag("Apple"))
            totalPrice -= applePrice;
        else if (ob.CompareTag("Tomato"))
            totalPrice -= tomatoPrice;
        UpdateTotalPrice();
    }

    // 가격을 출력한다.
    private void UpdateTotalPrice() 
    {
        totalPriceText.text = "가격:" + totalPrice.ToString("N0") + "원";
    }

}
