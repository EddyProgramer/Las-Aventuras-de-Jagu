using System.Collections;
using TMPro;
using UnityEngine;


public class DialogoSrMad : MonoBehaviour
{
   [SerializeField] private AudioSource tipeoSound;
     [SerializeField] private AudioSource enterSound;


   [SerializeField] private GameObject signoInterrogacion;
   [SerializeField] private GameObject teclaE;
   //creacion de array de strings para guardar los dialogos
    [SerializeField, TextArea(4,6)] private string[] lineasDialogoSrMad;
   [SerializeField] private GameObject Pdialogo;
   [SerializeField] private TMP_Text TdialogoSrmad;
    private bool jaguEstaCercaSrMad;
    private bool dialogoIniciadoSiNo;
    private int lineIndex;
    private float tiempoTipeo =0.15f;
        
    void Update()
    {
        if(jaguEstaCercaSrMad && Input.GetButtonDown("accion1"))
        {
            if(!dialogoIniciadoSiNo)
            {
                 IniciarDialogo();
            }
            else if (TdialogoSrmad.text==lineasDialogoSrMad[lineIndex])
            {
               SiguienteLineaTexto();
            }
            else
            {
               StopAllCoroutines();
               TdialogoSrmad.text=lineasDialogoSrMad[lineIndex];
            }
        }
    }
      private void IniciarDialogo()
      {
         dialogoIniciadoSiNo = true;
         Pdialogo.SetActive(true);
         signoInterrogacion.SetActive(false);
         teclaE.SetActive(false);
         lineIndex = 0;
         Time.timeScale = 0f;
         StartCoroutine(MostrarLinea());
      }

      // poder mostrar siguiente linea de dialogo
       private void SiguienteLineaTexto()
       {
         lineIndex++;
         if(lineIndex < lineasDialogoSrMad.Length)
         {
           StartCoroutine (MostrarLinea());
         }
         else
         {
           dialogoIniciadoSiNo = false;
           Pdialogo.SetActive(false);
           signoInterrogacion.SetActive(false);
           teclaE.SetActive(false);
           Time.timeScale = 1f;
         }
       }
      // corrutina para el manejo de array de texto
       private IEnumerator MostrarLinea()
       {
        TdialogoSrmad.text = string.Empty;
        
        foreach(char ch in lineasDialogoSrMad[lineIndex]  )
        {
          TdialogoSrmad.text += ch;
            yield return new WaitForSecondsRealtime(tiempoTipeo);
           tipeoSound.PlayOneShot(tipeoSound.clip); // Reproducir el sonido de tipeo
           
        }
       }
    private void  OnTriggerEnter2D(Collider2D Collision) {
     
       if(Collision.gameObject.CompareTag("Player")){

         jaguEstaCercaSrMad = true;
         signoInterrogacion.SetActive(true);
         teclaE.SetActive(true);
          if (enterSound != null) // Verifica si hay un sonido de entrada asignado
            {
                enterSound.Play(); // Reproduce el sonido de entrada si está asignado
            }

       }
       
        

        
    }

    private void OnTriggerExit2D(Collider2D Collision) {
         if(Collision.gameObject.CompareTag("Player")){

         jaguEstaCercaSrMad = false;
            signoInterrogacion.SetActive(false);
       }
       
    }
}
