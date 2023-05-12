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

    //������ ����.
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
    //���� ������. GameObjcet money�� ���� ���� ������ �޶�����.
    public void TakeOutMoney(GameObject money)
    {
        if (moneyOb == null)
        {
            moneyOb = Managers.Resource.Instantiate(money); //Prefabs ��ġ ����
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
