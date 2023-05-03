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


    
    private void OnTriggerEnter(Collider ob) // ���뿡 ������ ������ ������ ���Ѵ�.
    {
        if (ob.CompareTag("Apple"))
            Add(ob);
        else if (ob.CompareTag("Tomato"))
            Add(ob);
    }

    private void OnTriggerExit(Collider ob) // ���뿡�� ������ ������ ������ ����.
    {
        if (ob.CompareTag("Apple"))
            Substract(ob);
        else if (ob.CompareTag("Tomato"))
            Substract(ob);
    }

    private void Add(Collider ob) // ������ ���ϰ� ��ü������ ����Ѵ�.
    {
        if (ob.CompareTag("Apple"))
            totalPrice += applePrice;
        else if (ob.CompareTag("Tomato"))
            totalPrice += tomatoPrice;
        UpdateTotalPrice();
    }

    private void Substract(Collider ob) // ������ ���� ��ü������ ����Ѵ�.
    {
        if (ob.CompareTag("Apple"))
            totalPrice -= applePrice;
        else if (ob.CompareTag("Tomato"))
            totalPrice -= tomatoPrice;
        UpdateTotalPrice();
    }
 

    private void UpdateTotalPrice() // ������ ����Ѵ�.
    {
        totalPriceText.text = "����:" + totalPrice.ToString("N0") + "��";
    }

}
