using Microsoft.MixedReality.Toolkit.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonaction : MonoBehaviour, IMixedRealityTouchHandler
{
    public GameObject prefabToToggle;
    private bool isPrefabActive;
    private float delay = 2.0f;
    private bool isdelayed;

 
    private void Start()
    {
        isPrefabActive = false;
       
    }

    public void OnTouchStarted(HandTrackingInputEventData eventData)
    {
        if (!isPrefabActive)
        {
            ActivatePrefab();
        }
        else
        {
            DeactivatePrefab();
        }
        StartCoroutine(waittime());
    }



    IEnumerator waittime()     ///python contextmanager with문 참고
    {
        isdelayed = true;
        yield return new WaitForSeconds(delay);
        isdelayed = false;   
    }

    private void ActivatePrefab()
    {
        prefabToToggle.SetActive(true);
        isPrefabActive = true;
    }

    private void DeactivatePrefab()
    {
        prefabToToggle.SetActive(false);
        isPrefabActive = false;
    }

    /// <summary>
    /// IMixedRealityTouchHandler 의 인터페이스를 정의해주기위해 밑에 선언
    /// </summary>
    public void OnTouchCompleted(HandTrackingInputEventData eventData) { }
    public void OnTouchUpdated(HandTrackingInputEventData eventData) { }
    public void OnTouchCanceled(HandTrackingInputEventData eventData) { }
}
