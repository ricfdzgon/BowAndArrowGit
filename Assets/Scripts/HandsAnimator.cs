using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class HandsAnimator : MonoBehaviour
{
    Animator animator;
    private InputDevice targetDevice;

    //En esta variable pública seleccionaremos el tipo de dispositivo con el que queremos conectar
    public InputDeviceCharacteristics controllerCharacteristics;
    void Start()
    {
        // Lo primero es una referencia al animator
        animator = GetComponent<Animator>();
        TryInitialize();
    }

    void Update()
    {
        //En update miraremos cuál es el valor correspondiente el botón Grip y lo usaremos
        //para controlar el animador

        //Antes de mirar el valor del botón de grip, tengo que mirar si TargetDevice fue inicializado correctamente
        if (targetDevice != null)
        {
            //targetDevice está inicializado, leemos el valor del mando de grip
            float gripValue;
            //Esta é a instrucción que lee un valor dende un dispositivo
            //o primeiro parámetro é o que indica que valor queremos ler de entre os que poida ter o dispositivo
            //A función *intenta* obter o valor devolve un bool que indica se o conseguiu
            if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out gripValue))
            {
                //Isto execútase se o vakir se leu correctamente
                animator.SetFloat("Grip", gripValue);

            }
            else
            {
                //Isto executase no caso contrario
                animator.SetFloat("Grip", 0);
            }
        }
        else
        {
            //targetDevice no está inicializado, lo intentamos de nuevo
            TryInitialize();
        }

        //esto es una prueba para que la mano se abra y se cierre sin parar
        /*
        float pinpong = Mathf.PingPong(Time.time, 1);
        animator.SetFloat("Grip", pinpong);*/
    }

    private void TryInitialize()
    {
        //Nreste método intentaremos conectar co mando esquerdo,
        //Usando a variable controllerCharacteristics

        //A variable devices serve para recibir os dipositivos que vamos 
        // a buscar na seguinte instrucción
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        //Miramos se en devices, a nosa variable, hai algún dispositivo atopado
        if (devices.Count > 0)
        {
            //Tirando millas, vou supoñer que o dispositivo que nos interesa é o primeiro da lista
            // o cal é bastante lóxico por que non debería haber máis dun mando esquerdo
            targetDevice = devices[0];
        }
        else
        {
            //Para ver que se tarda un pouco en atopar o mando, poñemos un Debug.Log
            Debug.Log("HandsAnimator.TryInitialize dispositivo non atopado");
        }
    }
}
