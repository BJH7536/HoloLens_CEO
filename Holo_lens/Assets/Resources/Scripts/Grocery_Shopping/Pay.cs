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

    // 계산대에 돈이 들어오면 금액을 더한다.
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

    // 계산대에서 돈이 빠지면 금액을 뺀다.
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

    // 금액을 더하고 지불한 금액을 출력한다.
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

    // 금액을 빼고 지불한 금액을 출력한다.
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

    // 지불한 금액을 출력한다.
    private void UpdatePayment()
    {
        paymentText.text = "지불한 금액:" + payment.ToString("N0") + "원";
    }

    // 지불한 금액을 계산하여 거스름 돈을 출력한다. 지불한 금액이 더 작으면 부족한 금액을 출력한다.
    public void PayMoney()
    {
        if (payment >= Grocery_Shopping.Instance.totalPrice)
        {
           pay.text = "거스름 돈:" + (payment - Grocery_Shopping.Instance.totalPrice).ToString("N0") + "원";
          
           if(GameObject.Find(reset.name)==null)
             Managers.Resource.Instantiate(reset);
      
        }
        else
        {
           pay.text = (Grocery_Shopping.Instance.totalPrice-payment).ToString("N0") + "원이 부족합니다.";
        }
    }

}
