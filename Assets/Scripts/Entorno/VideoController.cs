



using UnityEngine;
using UnityEngine.Video;


public class VideoController : MonoBehaviour




{
    public VideoPlayer videoPlayer;
 
    [SerializeField] private AudioSource EnterSound;

   [SerializeField] private GameObject signoInterrogacion;
   [SerializeField] private GameObject teclaE;

 
   
  
    private bool jaguEstaCerca1;
      void Start()
    {
        // Configura el VideoPlayer para que no se reproduzca automáticamente al iniciar.
        videoPlayer.playOnAwake = false;
    }
 
        
    void Update()
    {
        if (jaguEstaCerca1 && Input.GetButtonDown("accion1"))
        {
            if (videoPlayer.isPlaying)
                videoPlayer.Pause();
            else
                videoPlayer.Play();
        }
    }
     
  
    private void  OnTriggerEnter2D(Collider2D Collision) {
     
       if(Collision.gameObject.CompareTag("Player")){

         jaguEstaCerca1= true;
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

         jaguEstaCerca1 = false;
            signoInterrogacion.SetActive(false);
             teclaE.SetActive(false);
       }
       
    }
}

