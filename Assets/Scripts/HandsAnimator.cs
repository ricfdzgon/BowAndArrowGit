using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsAnimator : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        // Lo primero es una referencia al animator
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //En update miraremos cuál es el valor correspondiente el botón Grip y lo usaremos
        //para controlar el animador

        //pero ahora vamos a hacer que la mano se abra y se cierre sin parar
        float pinpong = Mathf.PingPong(Time.time, 1);
        animator.SetFloat("Grip", pinpong);
    }
}
