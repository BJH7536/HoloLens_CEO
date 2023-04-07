using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BOX_GUESSING : MonoBehaviour
{
    public GameObject[] Qs;
    public GameObject[] Buttons;
    int[] Anums=new int[5];
    int Qnow;
    int Qnum;
    Vector3 QPos;
    GameObject AButton;
    

    private void Start()
    {
        QPos = findQ().transform.position;

        Questioning();
        BindButton();
    }

    private void Questioning()
    {
        HashSet<int> uniqueValues = new HashSet<int>();
        int s = UnityEngine.Random.Range(0, Buttons.Length);
        Qnum = findQ().GetComponentsInChildren<Transform>().Length - 1;
        uniqueValues.Add(Qnum);
        while (uniqueValues.Count < Buttons.Length)
        {
            int r = UnityEngine.Random.Range(Qnum - 3, Qnum + 3);
           
            uniqueValues.Add(r);
            
        }
        int[] Anums = uniqueValues.ToArray();

        for (int i = 0; i < Anums.Length; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, Anums.Length);
            int temp = Anums[i];
            Anums[i] = Anums[randomIndex];
            Anums[randomIndex] = temp;
        }

        for (int i = 0; i < Anums.Length; i++)
        {
            Buttons[i].GetComponent<ButtonConfigHelper>().MainLabelText = $"{Anums[i]}";
            if (Anums[i] == Qnum)
                AButton = Buttons[i];
        }

        Debug.Log($"{Anums[0]}" + $"{Anums[1]}" + $"{Anums[2]}" + $"{Anums[3]}" + $"{Anums[4]}");

    } 

    public void HightlightAButton()
    {
        AButton.transform.GetChild(1).GetChild(0).GetComponent<MeshOutline>().enabled = true;
    }

    public void BindButton()
    {
        foreach(GameObject go in Buttons)
        {
            go.GetComponent<Interactable>().OnClick.AddListener(HightlightAButton);
        }
    }
     
    public void BringNextQ()
    {
        DestroyImmediate(findQ());
        AButton.transform.GetChild(1).GetChild(0).GetComponent<MeshOutline>().enabled = false;

        Qnow = (Qnow + 1)%Qs.Length;
        GameObject NextQ = Managers.Resource.Instantiate(Qs[Qnow], transform);
        NextQ.transform.position = QPos;

        Questioning();
    }

    GameObject findQ()
    {
        int loopNum = 0;
        GameObject targetQ = null;
        foreach (Transform child in transform)
        { 
            if (child.GetComponent<BoxCollider>() != null)
                targetQ = child.gameObject;
            if (loopNum++ > 10000)
                throw new Exception("Infinite Loop");

        }
         return targetQ;
    }


}
