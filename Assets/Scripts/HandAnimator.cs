using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandAnimator : MonoBehaviour
{
    Animator animator;

    private InputDevice targetDevice;

    //En esta variable pública seleccionaremos el tipo de dispositivo con el que queremos conectar
    public InputDeviceCharacteristics controllerCharacteristics;

    // Start is called before the first frame update
    void Start()
    {
        //Lo primero es una referencia al animator
        animator = GetComponent<Animator>();
        TryInitialize();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("HandAnimator.Update principio ");
        //En update miraremos cual es el valor correspondiente al botón de Grip
        //y lo usaremos para controlar el animador       


        //Antes de mirar el valor del botón de grip, tengo que mirar si targetDevice fue
        //inicializado correctamente
        if (targetDevice != null)
        {
            //targetDevice está inicalizado, leemos el valor del mando de grip

            //na variable gripValue obteremos o valor
            float gripValue;

            //Esta é a instrución que lé un valor dende un dispositivo
            //o primeiro parámetro é o que indica que valor queremos ler de entre os que poida ter o dispositivo
            //A función *intenta* obter o valor e devolve un bool que indica se o conseguiu
            if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out gripValue))
            {
                //Isto execútase se o valor se leu correctamente. Usamos gripValue no animador
                animator.SetFloat("Grip", gripValue);
            }
            else
            {
                //Isto execútase no caso contrario
                animator.SetFloat("Grip", 0);
            }
            //Debug.Log("HandAnimator.Update " + gripValue);

        }
        else
        {
            //targetDevice no está inicializado, lo intentamos de nuevo
            TryInitialize();
        }

        //Quitamos esta proba de que la mano se abra y se cierre sin parar
        //float pingpong = Mathf.PingPong(Time.time, 1);
        //animator.SetFloat("Grip", pingpong);        
    }

    private void TryInitialize()
    {

        Debug.Log("TryInitialize inicio");
        //Neste método intentaremos conectar co mando esquerdo,
        //usando a variable controllerCharacteristics

        //A variable devices serve para recibir os dispositivos que vamos
        //a buscar na seguinte instrución
        List<InputDevice> devices = new List<InputDevice>();

        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        //Miramos se en devices, a nosa variable, hai algún dispositivo atopado
        if (devices.Count > 0)
        {
            //Tirando millas, vou supoñer que o dispositivo que nos interesa é o primeiro da lista
            //o cal é bastante lóxico porque non debería haber máis dun mando esquerdo
            targetDevice = devices[0];
            Debug.Log("TryInitialize dispositivo atopado");
        }
        else
        {
            //Para ver que se tarda un pouco en atopar o mando, poñemos un Debug.Log
            Debug.Log("TryInitialize dispositivo non atopado");
        }

    }
}
