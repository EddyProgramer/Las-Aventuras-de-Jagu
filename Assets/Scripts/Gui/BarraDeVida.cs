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

    public void CambiarMaxValueSlider (float vidaJagu){
   slider.maxValue = vidaJagu;

   }
   public void CambiarVidaActual(float vidaJagu)
   {
    slider.value = vidaJagu;

   }
  
   public void InicializarBarraDeVida(float vidaJagu)
   {
     
     CambiarMaxValueSlider (vidaJagu);
     CambiarVidaActual(vidaJagu);
   }
}