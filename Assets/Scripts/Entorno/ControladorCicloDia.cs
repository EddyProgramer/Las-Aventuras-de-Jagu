
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ControladorCicloDia : MonoBehaviour
{
   [SerializeField] private Light2D luzGLobal;
   [SerializeField] private CicloDia [] ciclosDia;
    [SerializeField] private float tiempoPorCiclo;
    private float tiempoActualCiclo = 0;
    private float porcentajeCiclo;
    private int cicloActual=0;
    private int  cicloSiguiente =1;

    private void  Start() {
        luzGLobal.color = ciclosDia[0].colorCiclo;
    }

    private void  Update() {
        tiempoActualCiclo += Time.deltaTime;
        porcentajeCiclo = tiempoActualCiclo/ tiempoPorCiclo;

        if(tiempoActualCiclo>=tiempoPorCiclo)
        {
         tiempoActualCiclo =0;

         cicloActual = cicloSiguiente;
           if(cicloSiguiente+1>ciclosDia.Length-1)
           {
             cicloSiguiente=0;
           }
           else
           {
             cicloSiguiente +=1;
           }
        }

        CambiarColor(ciclosDia[cicloActual].colorCiclo,ciclosDia[cicloSiguiente].colorCiclo);

    }

    //cambiar el color
    private void CambiarColor(Color colorActual,Color siguienteColor)
    {
        luzGLobal.color=Color.Lerp(colorActual,siguienteColor,porcentajeCiclo);
    }
}
