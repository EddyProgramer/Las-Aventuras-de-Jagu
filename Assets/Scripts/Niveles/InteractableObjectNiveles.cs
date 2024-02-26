
using UnityEngine;


public class InteractableObjectNiveles : MonoBehaviour
{
   [SerializeField] private AudioSource Level1Sound1;
    [SerializeField] private AudioSource EnterSound;

   [SerializeField] private GameObject signoInterrogacion;
   [SerializeField] private GameObject teclaE;
   //creacion de array de strings para guardar los dialogos
 
   
  
    private bool jaguEstaCerca;
 
        
    void Update()
    {
        if (jaguEstaCerca && Input.GetButtonDown("accion1"))
        {
            if (Level1Sound1.isPlaying) // Verifica si el sonido está reproduciéndose
            {
                Level1Sound1.Stop(); // Detiene la reproducción actual
                Level1Sound1.Play(); // Vuelve a reproducir desde el principio
            }
            else
            {
                Level1Sound1.Play(); // Reproduce el sonido si no está reproduciéndose
            }
        }
    }
     
  
    private void  OnTriggerEnter2D(Collider2D Collision) {
     
       if(Collision.gameObject.CompareTag("Player")){

         jaguEstaCerca= true;
         signoInterrogacion.SetActive(true);
         teclaE.SetActive(true);
           if (EnterSound != null) // Verifica si hay un sonido de entrada asignado
            {
                EnterSound.Play(); // Reproduce el sonido de entrada si está asignado
            }

       }
       
        

        
    }

    private void OnTriggerExit2D(Collider2D Collision) {
         if(Collision.gameObject.CompareTag("Player")){

         jaguEstaCerca = false;
            signoInterrogacion.SetActive(false);
             teclaE.SetActive(false);
       }
       
    }
}
