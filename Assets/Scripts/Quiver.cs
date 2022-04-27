using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Quiver : XRBaseInteractable
{
    public GameObject arrowPrefab;
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

    void Start()
    {
        if (arrowPrefab == null)
        {
            Debug.Log("Quiver.Start arrowPrefab está sin establecer");
        }
    }

    public void CreateAndSelectArrow(SelectEnterEventArgs args)
    {
        if (GameManager.instance.PuedeSeguirJugando())
        {
            Debug.Log("Qiver.CreateAndSelectArrow");
            Arrow arrow = CreateArrow(args.interactorObject.transform);
            interactionManager.SelectEnter(args.interactorObject, arrow);
            GameManager.instance.NewArrow(arrow);
        }
    }

    private Arrow CreateArrow(Transform arrowPositionAndOrientation)
    {
        GameObject arrowObject = Instantiate(arrowPrefab, arrowPositionAndOrientation.position, arrowPositionAndOrientation.rotation);
        return arrowObject.GetComponent<Arrow>();
    }
}
