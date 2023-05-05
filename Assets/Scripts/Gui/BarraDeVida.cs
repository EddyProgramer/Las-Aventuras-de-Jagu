using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BarraDeVida : MonoBehaviour
{
   [SerializeField] Slider slider;
 
 
    public void Start()
   {
     slider = GetComponent<Slider>();
   }

   public void CambiarVidaMaxima(float vidaMaxima)

  {
     slider.maxValue = vidaMaxima;
  }

   
   public void CambiarVidaActual(float cantidadvida)
   {
    slider.value = cantidadvida;

   }

   public void InicializarBarraDeVida(float cantidadvida)
   {
     
     CambiarVidaMaxima(cantidadvida);
     CambiarVidaActual(cantidadvida);
   }
}
