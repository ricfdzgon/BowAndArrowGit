using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringRenderer : MonoBehaviour
{
    public Transform top;
    public Transform middle;
    public Transform bottom;

    public LineRenderer lineRenderer;


    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePositions();
    }

    void UpdatePositions()
    {
        Vector3[] positions = new Vector3[] { top.position, middle.position, bottom.position };
        lineRenderer.SetPositions(positions);
    }
}
