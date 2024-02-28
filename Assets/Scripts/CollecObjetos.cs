
using UnityEngine;

public class CollecObjetos : MonoBehaviour
{
   [SerializeField] private GameObject efecto;
   [SerializeField] private int  cantidadPuntos;
   [SerializeField] private Puntaje puntaje;
    // Agrega esta variable para el sonido
     [SerializeField] private AudioSource sonidoCristal;// Agrega esta variable para el componente AudioSource
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
         {
           
            puntaje.SumarPuntos(cantidadPuntos);
           Instantiate(efecto, transform.position,Quaternion.identity);
           
           Destroy(gameObject); 
         }
        
    }
        


         private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
         {
            ReproducirSonidoCuracion();
         
         }
        
    }

     private void ReproducirSonidoCuracion()
    {

        Debug.Log("Reproduciendo sonido de curación");
      
       
        if (sonidoCristal != null && sonidoCristal.clip != null)
        {
              sonidoCristal.PlayOneShot(sonidoCristal.clip);
        }
         else
       {
        Debug.LogWarning("AudioSource de curación no está configurado correctamente.");
       }
    }
    
}


