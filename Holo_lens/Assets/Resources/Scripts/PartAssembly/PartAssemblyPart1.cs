using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;
using static MRTK.Tutorials.GettingStarted.PartAssemblyController;

public class PartAssemblyPart1 : MonoBehaviour { 

    private bool isPunEnabled;
    private bool shouldCheckPlacement;

    [SerializeField] public Transform locationToPlace = default;

    private List<Collider> colliders;

    private Transform originalParent;
    private Vector3 originalPosition;
    private Quaternion originalRotation;


    public bool isPlaced;

    public bool IsPunEnabled
    {
        set => isPunEnabled = value;
    }


    // Start is called before the first frame update
    void Start()
    {
        if (locationToPlace != transform) shouldCheckPlacement = true;

        colliders = new List<Collider>();
        if (shouldCheckPlacement)
            foreach (var col in GetComponents<SphereCollider>())
                colliders.Add(col);



        var trans = transform;
        originalParent = trans.parent;
        originalPosition = trans.localPosition;
        originalRotation = trans.localRotation;



    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Collider>() == locationToPlace.GetComponent<Collider>())
        {
            SetPlacement();
        }
    }



    private void OnCollisionStay(Collision collision)
    {
        if (isPlaced)
        {
            var trans = transform;
            trans.position = locationToPlace.position;
            trans.rotation = locationToPlace.rotation;

        }
    }



    //// Update is called once per frame
    public void Set()
    {
        // Update placement state
        isPlaced = true;

        // Play audio snapping sound

        // Disable ability to manipulate object
        foreach (var col in colliders) col.enabled = false;

        // Disable tool tips

        // Set parent and placement of object to target
        var trans = transform;
        trans.rotation = locationToPlace.rotation;
        trans.SetParent(locationToPlace.parent);
        trans.position = locationToPlace.position;
    }

    private void SetPlacement()
    {
        if (isPunEnabled)
            OnSetPlacement?.Invoke();
        else
            Set();
    }
    public event PartAssemblyControllerDelegate OnResetPlacement;

    public event PartAssemblyControllerDelegate OnSetPlacement;
}
