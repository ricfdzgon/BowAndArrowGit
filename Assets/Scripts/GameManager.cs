using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Marcador marcador;
    private int numeroFrechasLanzadas;
    private int puntuacionUltimo = 0, puntuacionTotal = 0;
    // Start is called before the first frame update

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Debug.Log("GameManager.Start marcador está sen establecer");
        numeroFrechasLanzadas = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void frechaLanzada(Arrow arrow)
    {
        numeroFrechasLanzadas++;
        marcador.SetNumeroFrechas(numeroFrechasLanzadas);
        //Actualizamos o marcador para que mostre 0 na puntuación da última flecha lanzada
        marcador.SetPuntuacion(0, puntuacionTotal);
    }

    public void AnotarPuntos(int puntos)
    {
        puntuacionUltimo = puntos;
        puntuacionTotal += puntuacionUltimo;
        marcador.SetPuntuacion(puntuacionUltimo, puntuacionTotal);
    }
}
