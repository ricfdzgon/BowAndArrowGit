using UnityEngine;

public class Target : MonoBehaviour, IArrowHittable
{
    public float forceAmount = 1.0f;
    public Material otherMaterial = null;

    //radio do circulo central, valorado en 10 pontos
    private float radioDivisionCentral = 0.037f;

    //Radio exterior da diana, correspondente ó borde exterior da zona que vale 1 punto
    private float radioExterior = 0.49f;

    //Ancho das zonas concentricas que valen entre 1 e 9 puntos 
    private float anchoZona;

    void Start()
    {
        anchoZona = (radioExterior - radioDivisionCentral) / 9;
    }
    public void Hit(Arrow arrow, RaycastHit hit)
    {
        float distanciaImpacto = (hit.point - transform.position).magnitude;
        int points = 0;

        if (distanciaImpacto > radioExterior)
        {
            points = 0;
        }
        else
        {
            if (distanciaImpacto <= radioDivisionCentral)
            {
                points = 10;
            }
            else
            {
                float zona = (distanciaImpacto - radioDivisionCentral) / anchoZona;
                points = 9 - Mathf.FloorToInt(zona);
            }
        }
        GameManager.instance.AnotarPuntos(points);
    }

    private void ApplyMaterial()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = otherMaterial;
    }

    private void ApplyForce(Vector3 direction)
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(direction * forceAmount);
    }
}
