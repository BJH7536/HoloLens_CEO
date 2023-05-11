using Microsoft.MixedReality.Toolkit.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Grocery_Shopping : MonoBehaviour
{
    //����
    public int tomatoPrice = 1000;
    public int applePrice = 500;
    private int totalPrice = 0;

    public TextMeshPro totalPriceText;
    // ���뿡 ������ ������ ������ ���Ѵ�.
    private void OnTriggerEnter(Collider ob)
    {
        if (ob.CompareTag("Apple"))
            Add(ob);
        else if (ob.CompareTag("Tomato"))
            Add(ob);
    }

    // ���뿡�� ������ ������ ������ ����.
    private void OnTriggerExit(Collider ob) 
    {
        if (ob.CompareTag("Apple"))
            Substract(ob);
        else if (ob.CompareTag("Tomato"))
            Substract(ob);
    }

    // ������ ���ϰ� ��ü������ ����Ѵ�.
    private void Add(Collider ob) 
    {
        if (ob.CompareTag("Apple"))
            totalPrice += applePrice;
        else if (ob.CompareTag("Tomato"))
            totalPrice += tomatoPrice;
        UpdateTotalPrice();
    }

    // ������ ���� ��ü������ ����Ѵ�.
    private void Substract(Collider ob) 
    {
        if (ob.CompareTag("Apple"))
            totalPrice -= applePrice;
        else if (ob.CompareTag("Tomato"))
            totalPrice -= tomatoPrice;
        UpdateTotalPrice();
    }

    // ������ ����Ѵ�.
    private void UpdateTotalPrice() 
    {
        totalPriceText.text = "����:" + totalPrice.ToString("N0") + "��";
    }

}
