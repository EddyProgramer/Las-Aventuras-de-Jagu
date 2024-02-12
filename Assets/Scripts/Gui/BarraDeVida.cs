using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class BarraDeVida : MonoBehaviour
{
   [SerializeField] Slider slider;
 
 
    public void Start()
   {
     slider = GetComponent<Slider>();
   }

    public void CambiarMaxValueSlider (int vidaJagu){
   slider.maxValue = vidaJagu;

   }
   public void CambiarVidaActual(int vidaJagu)
   {
    slider.value = vidaJagu;

   }
  
   public void InicializarBarraDeVida(int vidaJagu)
   {
     
     CambiarMaxValueSlider (vidaJagu);
     CambiarVidaActual(vidaJagu);
   }

    public void SetearBarraVida(int barravidaSet){
      
      slider.maxValue = barravidaSet;


    }
}