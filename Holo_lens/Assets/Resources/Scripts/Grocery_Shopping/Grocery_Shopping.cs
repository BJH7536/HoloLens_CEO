using Microsoft.MixedReality.Toolkit.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Grocery_Shopping : MonoBehaviour
{
    private static Grocery_Shopping instance;
    //가격
    public int tomatoPrice = 1000;
    public int applePrice = 500;
    public int pizzaPrice = 8500;
    public int totalPrice = 0;
    public TextMeshPro totalPriceText;
    public TextMeshPro question;
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

    private void Start()
    {
        Question();
    }



    // 계산대에 물건이 들어오면 가격을 더한다.
    private void OnTriggerEnter(Collider ob)
    {
        if (ob.CompareTag("Apple"))
            Add(ob);
        else if (ob.CompareTag("Tomato"))
            Add(ob);
        else if (ob.CompareTag("Pizza"))
            Add(ob);
    }

    // 계산대에서 물건이 빠지면 가격을 뺀다.
    private void OnTriggerExit(Collider ob) 
    {
        if (ob.CompareTag("Apple"))
            Substract(ob);
        else if (ob.CompareTag("Tomato"))
            Substract(ob);
        else if (ob.CompareTag("Pizza"))
            Substract(ob);
    }

    // 가격을 더하고 전체가격을 출력한다.
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

    // 가격을 빼고 전체가격을 출력한다.
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

    // 가격을 출력한다.
    private void UpdateTotalPrice() 
    {
        totalPriceText.text = "가격:" + totalPrice.ToString("N0") + "원";
    }
    //구매해야할 물품을 랜덤으로 알려준다.
    private void Quest()
    {
        string[] ob = { "사과", "바나나", "오렌지", "포도", "수박", "참외" };
        int minCount = 1;
        int maxCount = 5;

        int obCount = UnityEngine.Random.Range(1, 4);
        string[] selectedob = new string[obCount];

        for (int i = 0; i < obCount; i++)
        {
            int index = UnityEngine.Random.Range(0, ob.Length);
            selectedob[i] = ob[index];
        }

        string[] obstring = new string[obCount];
        for (int i = 0; i < obCount; i++)
        {
            int count = UnityEngine.Random.Range(minCount, maxCount + 1);
            obstring[i] = string.Format("{0}{1}개", selectedob[i], count);
        }

        string result = string.Join(",", obstring);
        question.text = string.Format("{0}를 구매하세요", result);

    
    }

}
