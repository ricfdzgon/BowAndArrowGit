using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Marcador : MonoBehaviour {
    public TextMeshProUGUI numeroFrechasText;
    // Start is called before the first frame update
    void Start() {
        if(numeroFrechasText == null) {
            Debug.Log("Marcador.Start o campo de texto numeroFrechas sen establecer");
        }        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetNumeroFrechas(int numeroFrechas) {
        numeroFrechasText.text = numeroFrechas.ToString();
    }
}
