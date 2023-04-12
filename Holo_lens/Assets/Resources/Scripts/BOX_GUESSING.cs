using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Utilities;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BOX_GUESSING : MonoBehaviour
{
    public GameObject[] Qs;
    public GameObject[] Buttons;
    int[] Anums = new int[5];
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
        int s = Random.Range(0, Buttons.Length);
        Qnum = findQ().GetComponentsInChildren<Transform>().Length - 1;
        Anums[s] = Qnum;
        for (int i = 0; i < Anums.Length; i++)
        {
            int r = Random.Range(Qnum - 3, Qnum + 3);
            if (r != Qnum && !Anums.Contains(r))
                Anums[i] = r;
            else
                i--;
        }

        for (int i = 0; i < Anums.Length; i++)
        {
            Buttons[i].GetComponent<ButtonConfigHelper>().MainLabelText = $"{Anums[i]}";
        }

        AButton = Buttons[s];
        AButton.GetComponent<ButtonConfigHelper>().MainLabelText = $"{Qnum}";
        
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
        GameObject targetQ = null;
        foreach (Transform child in transform)
        {
            if (child.GetComponent<BoxCollider>() != null)
                targetQ = child.gameObject;
        }
        return targetQ;
    }


}
