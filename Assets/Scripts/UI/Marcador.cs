using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Marcador : MonoBehaviour
{
    public TextMeshProUGUI numeroFrechasText;
    public TextMeshProUGUI numeroPuntosTotales;
    public TextMeshProUGUI numeroPuntosUltimo;

    // Start is called before the first frame update
    void Start()
    {
        if (numeroFrechasText == null)
        {
            Debug.Log("Marcador.Start o campo de texto numeroFrechas sen establecer");
        }
        if (numeroPuntosTotales == null)
        {
            Debug.Log("Marcador.Start o campo de texto numeroPuntosTotales sen establecer");
        }
        if (numeroPuntosUltimo == null)
        {
            Debug.Log("Marcador.Start o campo de texto numeroPuntosUltimo sen establecer");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetNumeroFrechas(int numeroFrechas)
    {
        numeroFrechasText.text = numeroFrechas.ToString();
    }

    public void SetPuntuacion(int points, int pointsTotales)
    {
        numeroPuntosUltimo.text = points.ToString();
        numeroPuntosTotales.text = pointsTotales.ToString();
    }

}
