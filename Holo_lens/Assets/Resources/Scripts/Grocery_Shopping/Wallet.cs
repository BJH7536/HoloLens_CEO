using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Wallet : MonoBehaviour
{

    public GameObject wallet;
    private GameObject walletOb;

    private GameObject moneyOb;
    private Vector3 lastPosition;

    //지갑을 연다.
    public void WalletOpen()
    {

        if (walletOb == null)
        {

            walletOb = Managers.Resource.Instantiate(wallet, transform);
            walletOb.transform.localPosition = new Vector3(-0.12f, -0.1f, -0.008f);

        }
        else
            DestroyImmediate(walletOb);

    }
    //돈을 꺼낸다. GameObjcet money에 따라 돈의 가격이 달라진다.
    public void TakeOutMoney(GameObject money)
    {
        if (moneyOb == null)
        {
            moneyOb = Managers.Resource.Instantiate(money); //Prefabs 위치 주의
            lastPosition = moneyOb.transform.position;
        }
        else
        {
           moneyOb=Managers.Resource.Instantiate(money);
           moneyOb.transform.localPosition = lastPosition+new Vector3(0.05f, 0.0f, 0.0f);
           lastPosition=moneyOb.transform.position;
        }
    }

}
