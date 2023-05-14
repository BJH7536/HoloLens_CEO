using Microsoft.MixedReality.Toolkit.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Grocery_Shopping : MonoBehaviour
{
    private static Grocery_Shopping instance;

    private Grocery_Shopping() { }
    public static Grocery_Shopping Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Grocery_Shopping>();
            }
            return instance;
        }
    }

    //����
    public int tomatoPrice = 1000;
    public int applePrice = 500;
    public int pizzaPrice = 8500;
    public int totalPrice = 0;
    public TextMeshPro totalPriceText;

    // ���뿡 ������ ������ ������ ���Ѵ�.
    private void OnTriggerEnter(Collider ob)
    {
        if (ob.CompareTag("Apple"))
            Add(ob);
        else if (ob.CompareTag("Tomato"))
            Add(ob);
        else if (ob.CompareTag("Pizza"))
            Add(ob);
    }

    // ���뿡�� ������ ������ ������ ����.
    private void OnTriggerExit(Collider ob) 
    {
        if (ob.CompareTag("Apple"))
            Substract(ob);
        else if (ob.CompareTag("Tomato"))
            Substract(ob);
        else if (ob.CompareTag("Pizza"))
            Substract(ob);
    }

    // ������ ���ϰ� ��ü������ ����Ѵ�.
    private void Add(Collider ob) 
    {
        if (ob.CompareTag("Apple"))
            totalPrice += applePrice;
        else if (ob.CompareTag("Tomato"))
            totalPrice += tomatoPrice;
        else if (ob.CompareTag("Pizza"))
            totalPrice += pizzaPrice;
        UpdateTotalPrice();
    }

    // ������ ���� ��ü������ ����Ѵ�.
    private void Substract(Collider ob) 
    {
        if (ob.CompareTag("Apple"))
            totalPrice -= applePrice;
        else if (ob.CompareTag("Tomato"))
            totalPrice -= tomatoPrice;
        else if (ob.CompareTag("Pizza"))
            totalPrice -= pizzaPrice;
        UpdateTotalPrice();
    }

    // ������ ����Ѵ�.
    private void UpdateTotalPrice() 
    {
        totalPriceText.text = "����:" + totalPrice.ToString("N0") + "��";
    }

}
