using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.XR.CoreUtils;
using UnityEngine;

public class Pay : MonoBehaviour
{ 

    private int payment = 0;
    public TextMeshPro paymentText;
    public TextMeshPro pay;
    public GameObject reset;

    // ���뿡 ���� ������ �ݾ��� ���Ѵ�.
    private void OnTriggerEnter(Collider ob)
    {
        if (ob.CompareTag("Money50000"))
            Add(ob);
        else if (ob.CompareTag("Money10000"))
            Add(ob);
        else if (ob.CompareTag("Money5000"))
            Add(ob);
        else if (ob.CompareTag("Money1000"))
            Add(ob);
        else if (ob.CompareTag("Money500"))
            Add(ob);
        else if (ob.CompareTag("Money100"))
            Add(ob);
    }

    // ���뿡�� ���� ������ �ݾ��� ����.
    private void OnTriggerExit(Collider ob)
    {
        if (ob.CompareTag("Money50000"))
            Substract(ob);
        else if (ob.CompareTag("Money10000"))
            Substract(ob);
        else if (ob.CompareTag("Money5000"))
            Substract(ob);
        else if (ob.CompareTag("Money1000"))
            Substract(ob);
        else if (ob.CompareTag("Money500"))
            Substract(ob);
        else if (ob.CompareTag("Money100"))
            Substract(ob);
    }

    // �ݾ��� ���ϰ� ������ �ݾ��� ����Ѵ�.
    private void Add(Collider ob)
    {
        if (ob.CompareTag("Money50000"))
            payment+= 50000;
        else if(ob.CompareTag("Money10000"))
            payment += 10000;
        else if (ob.CompareTag("Money5000"))
            payment += 5000;
        else if (ob.CompareTag("Money1000"))
            payment += 1000;
        else if (ob.CompareTag("Money500"))
            payment += 500;
        else if (ob.CompareTag("Money100"))
            payment += 100;
        UpdatePayment();
    }

    // �ݾ��� ���� ������ �ݾ��� ����Ѵ�.
    private void Substract(Collider ob)
    {
        if (ob.CompareTag("Money50000"))
            payment -= 50000;
        else if (ob.CompareTag("Money10000"))
            payment -= 10000;
        else if (ob.CompareTag("Money5000"))
            payment -= 5000;
        else if (ob.CompareTag("Money1000"))
            payment -= 1000;
        else if (ob.CompareTag("Money500"))
            payment -= 500;
        else if (ob.CompareTag("Money100"))
            payment -= 100;
        UpdatePayment();
    }

    // ������ �ݾ��� ����Ѵ�.
    private void UpdatePayment()
    {
        paymentText.text = "������ �ݾ�:" + payment.ToString("N0") + "��";
    }

    // ������ �ݾ��� ����Ͽ� �Ž��� ���� ����Ѵ�. ������ �ݾ��� �� ������ ������ �ݾ��� ����Ѵ�.
    public void PayMoney()
    {
        int change = payment - Grocery_Shopping.Instance.totalPrice;
        if (payment >= Grocery_Shopping.Instance.totalPrice)
        {
           int[] moneyUnit = { 50000, 10000, 5000, 1000, 500, 100};
           int[] count = new int[moneyUnit.Length];
           int changeNum = 0;
           for (int i = 0; i < moneyUnit.Length; i++)
           {
                if (change >= moneyUnit[i])
                {
                    count[i] = change / moneyUnit[i];
                    change %= moneyUnit[i];
                    if (count[i] > 0)
                        changeNum++;
                }
           }
           int j = 0;
           string[] changeString = new string[changeNum];
           for (int i = 0; i < moneyUnit.Length; i++)
           {
                if (count[i] != 0)
                    changeString[j++] = string.Format("{0}�� {1}��", moneyUnit[i].ToString("N0"), count[i]);
           }

           string result = string.Join(",",changeString);
           
          
           pay.text = "�Ž��� ��:"+ (payment - Grocery_Shopping.Instance.totalPrice).ToString("N0")+"��\n"+result;
            
           if (GameObject.Find(reset.name)==null)
                Managers.Resource.Instantiate(reset);
      
        }
        else
        {
           pay.text = (Grocery_Shopping.Instance.totalPrice-payment).ToString("N0") + "���� �����մϴ�.";
        }
    }

}
