using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class Quiver : XRBaseInteractable
{
    public GameObject arrowPrefab;

    void Start()
    {
        if (arrowPrefab == null)
        {
            Debug.Log("Quiver.Start: arrorPrefab sin establecer");
        }
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        selectEntered.AddListener(CreateAndSelectArrow);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        selectEntered.RemoveListener(CreateAndSelectArrow);
    }

    private void CreateAndSelectArrow(SelectEnterEventArgs args)
    {
        Debug.Log("Quiver.CreateAndSelectArrow");
        Arrow arrow = CreateArrow(args.interactableObject.transform);
        interactionManager.SelectEnter(args.interactorObject, arrow);
    }

    private Arrow CreateArrow(Transform arrowPositionAndOrientation)
    {
        GameObject arrowObject = Instantiate(arrowPrefab, arrowPositionAndOrientation.position, arrowPositionAndOrientation.rotation);
        return arrowObject.GetComponent<Arrow>();
    }
}
