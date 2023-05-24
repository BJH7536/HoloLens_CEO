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
    //����
    public int tomatoPrice = 1000;
    public int applePrice = 500;
    public int pizzaPrice = 8500;
    public int totalPrice = 0;
    public TextMeshPro totalPriceText;
    public TextMeshPro question;
    private Grocery_Shopping() { }
    //����
    public int tomatoPrice = 1000;
    public int applePrice = 500;
    public int pizzaPrice = 8500;
    public int totalPrice = 0;
    public TextMeshPro totalPriceText;
    public TextMeshPro question;
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

<<<<<<< Updated upstream
    private void Start()
    {
        Question();
    }


=======
    void Start()
    {
       
        Question();
    }   
>>>>>>> Stashed changes

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
    //�����ؾ��� ��ǰ�� �������� �˷��ش�.
    private void Quest()
    {
        string[] ob = { "���", "�ٳ���", "������", "����", "����", "����" };
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
            obstring[i] = string.Format("{0}{1}��", selectedob[i], count);
        }

        string result = string.Join(",", obstring);
        question.text = string.Format("{0}�� �����ϼ���", result);

    
    }

    private void Question()
    {
         string[] fruits = { "���", "�ٳ���", "������", "����", "����", "����" };
         int minCount = 1;
         int maxCount = 5;

        
        int[] randomIndex = new int[3];string fruit1 = fruits[UnityEngine.Random.Range(0, fruits.Length)];
        string fruit2 = fruits[UnityEngine.Random.Range(0, fruits.Length)];
        int count1 = UnityEngine.Random.Range(minCount, maxCount + 1);
        int count2 = UnityEngine.Random.Range(minCount, maxCount + 1);

        question.text =string.Format("{0}{1}�� {2}{3}���� �缼��", fruit1, count1, fruit2, count2);
        
    }
}
