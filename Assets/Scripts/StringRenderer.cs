using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringRenderer : MonoBehaviour
{
    public Transform top;
    public Transform bottom;
    public Transform middle;
    public LineRenderer lineRenderer;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        UpdatePositions();
    }

    void UpdatePositions()
    {
        Vector3[] Positions = new Vector3[] { top.position, middle.position, bottom.position };
        lineRenderer.SetPositions(Positions);
    }
}
