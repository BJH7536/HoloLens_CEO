using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Wallet : MonoBehaviour
{
    //other UI Open 
    public GameObject ob;



 
    
    public void WalletClose()
    {
        transform.position = new Vector3(-0.05f, -0.03f, 0.5f);
    }
      

    public void WalletOpen()
    {

        GameObject wallet = Instantiate(ob);
        wallet.transform.SetParent(transform, false);
        wallet.transform.localPosition=new Vector3(-0.12f, -0.1f, 0); 
        Debug.Log(transform.position);


    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
