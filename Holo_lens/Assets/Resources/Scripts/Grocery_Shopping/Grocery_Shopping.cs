using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Utilities.FigmaImporter;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Grocery_Shopping : MonoBehaviour
{
    private static Grocery_Shopping instance;
    //가격
    public int watermelonPrice = 15000;
    public int applePrice = 1100;
    public int cokePrice = 1200;
    public int beerPrice = 2700;
    public int bananaPrice = 900;
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
        Quest();
    }




    // 계산대에 물건이 들어오면 가격을 더한다.
    private void OnTriggerEnter(Collider ob)
    {
        if (ob.CompareTag("Apple"))
            Add(ob);
        else if(ob.CompareTag("Watermelon"))
            Add(ob);
        else if (ob.CompareTag("Coke"))
            Add(ob);
        else if (ob.CompareTag("Beer"))
            Add(ob);
        else if (ob.CompareTag("Banana"))
            Add(ob);
        
        
    }

    // 계산대에서 물건이 빠지면 가격을 뺀다.
    private void OnTriggerExit(Collider ob) 
    {
        if (ob.CompareTag("Apple"))
            Substract(ob);
        else if (ob.CompareTag("Watermelon"))
            Substract(ob);
        else if (ob.CompareTag("Coke"))
            Substract(ob);
        else if (ob.CompareTag("Beer"))
            Substract(ob);
        else if (ob.CompareTag("Banana"))
            Substract(ob);
        
    }

    // 가격을 더하고 전체가격을 출력한다.
    private void Add(Collider ob) 
    {
        if (ob.CompareTag("Apple"))
            totalPrice += applePrice;
        else if (ob.CompareTag("Watermelon"))
            totalPrice += watermelonPrice;
        else if (ob.CompareTag("Coke"))
            totalPrice += cokePrice;
        else if (ob.CompareTag("Beer"))
            totalPrice += beerPrice;
        else if (ob.CompareTag("Banana"))
            totalPrice += bananaPrice;


        
        UpdateTotalPrice();
    }

    // 가격을 빼고 전체가격을 출력한다.
    private void Substract(Collider ob) 
    {
        if (ob.CompareTag("Apple"))
            totalPrice -= applePrice;
        else if (ob.CompareTag("Watermelon"))
            totalPrice -= watermelonPrice;
        else if (ob.CompareTag("Coke"))
            totalPrice -= cokePrice;
        else if (ob.CompareTag("Beer"))
            totalPrice -= beerPrice;
        else if (ob.CompareTag("Banana"))
            totalPrice -= bananaPrice;
        
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
        string[] ob = { "수박", "바나나", "사과", "콜라", "맥주" };
        int minCount = 1;
        int maxCount = 2;

        int obCount = UnityEngine.Random.Range(1, 5);
        string[] selectedob = new string[obCount];

        for (int i = 0; i < obCount; i++)
        {
            int index = UnityEngine.Random.Range(0, ob.Length);

            //중복 제거
            for (int j = 0; j < i; j++)
            {
                if (selectedob[j] == ob[index])
                {
                    index = UnityEngine.Random.Range(0, ob.Length);
                    j = -1;
                }
            }
            selectedob[i] = ob[index];

        }

        string[] obstring = new string[obCount];
        for (int i = 0; i < obCount; i++)
        {
            int count = UnityEngine.Random.Range(minCount, maxCount + 1);
            obstring[i] = string.Format("{0} {1}개", selectedob[i], count);
        }

        string result = string.Join(",", obstring);
        question.text = string.Format("{0}를 구매하세요", result);

    
    }

    private void Question()
    {
         string[] fruits = { "사과", "바나나", "오렌지", "포도", "수박", "참외" };
         int minCount = 1;
         int maxCount = 5;

        
        int[] randomIndex = new int[3];string fruit1 = fruits[UnityEngine.Random.Range(0, fruits.Length)];
        string fruit2 = fruits[UnityEngine.Random.Range(0, fruits.Length)];
        int count1 = UnityEngine.Random.Range(minCount, maxCount + 1);
        int count2 = UnityEngine.Random.Range(minCount, maxCount + 1);

        question.text =string.Format("{0}{1}개 {2}{3}개를 사세요", fruit1, count1, fruit2, count2);
        
    }
}
